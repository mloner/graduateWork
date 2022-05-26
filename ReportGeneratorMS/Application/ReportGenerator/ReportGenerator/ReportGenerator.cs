using System;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Threading.Tasks;
using GeneratorDataBase;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReportingFramework.Dto;
using SectionModels;

namespace ReportGenerator
{
    public class ReportGenerator : IReportingGenerator
    {
        private IReportGeneratorRepository _reportGeneratorRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<IReportingGenerator> _logger;

        public ReportGenerator(
            IReportGeneratorRepository reportGeneratorRepository,
            IServiceProvider serviceProvider,
            ILogger<ReportGenerator> logger)
        {
            _reportGeneratorRepository = reportGeneratorRepository;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        
        public async Task<IReportGenerator> GenerateAsync(JsonElement reportModelJson, Guid reportGuid)
        {
            _logger.LogInformation($"ReportGuid: {reportGuid} start");
            
            var baseReportModel = JsonConvert.DeserializeObject<ReportModelExtended>(reportModelJson.ToString());
            var reportGenerator = ReportGeneratorHelper.GetReportGenerator(baseReportModel.ReportFormat, _serviceProvider);
            reportGenerator.Init(reportModelJson, reportGuid);
            reportGenerator.Generate();
            await _reportGeneratorRepository.SetReportLink(reportGuid, reportGenerator._reportPath);
            await _reportGeneratorRepository.SetReportStatus(reportGuid, ReportStatus.Done);
            
            _logger.LogInformation($"ReportGuid: {reportGuid} done");
            
            return reportGenerator;
        }

        public async Task<CustomFile> GetReportWithDataAsync(Guid reportGuid)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    //add report file
                    var report = await _reportGeneratorRepository.GetReportByGuid(reportGuid);
                    archive.CreateEntryFromFile(report.Link, Path.GetFileName(report.Link), CompressionLevel.Fastest);
                    
                    //add data file
                    var dataFile = archive.CreateEntry($"{reportGuid}_data.json");
                    await using (var entryStream = dataFile.Open())
                    await using (var streamWriter = new StreamWriter(entryStream))
                    {
                        await streamWriter.WriteAsync(report.Parameters);
                    }
                }
                    
                memoryStream.Seek(0, SeekOrigin.Begin);

                var nameWithExtension = $"{reportGuid}.zip";
                return new CustomFile
                {
                    Bytes = memoryStream.ToArray(),
                    ContentType = System.Net.Mime.MediaTypeNames.Application.Zip,
                    FileName = nameWithExtension
                };
            }
        }
    }
}