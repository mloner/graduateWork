#nullable enable
using System;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Threading.Tasks;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.DBDTOs.ReportDtos;
using CugReportMicroservice.Dtos.Exceptions.Init;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReportGeneratorClient;
using ReportingFramework;
using ReportNameManager;
using ReportNameManager.ReportNameManagers;
using SectionModels;

namespace ReportingOrchestrator
{
    public class Orchestrator : IOrchestrator
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IReportRepository _reportRepository;
        private readonly IReportingAdapter _reportingAdapter;
        private readonly IReportingAssembler _reportAssembler;
        private readonly IReportGeneratorClient _reportGeneratorClient;
        

        private string _reportParametersJson;
        private ReportParameters _reportParameters;
        private int _reportId;
        private Guid _reportGuidInGenerator;
        private ReportModel _reportModel;
        private string _reportDataFolder;
        private string _reportFullPath;
        private ReportParameters? _baseReportParameters;


        public Orchestrator(
            ILogger<Orchestrator> logger,
            IConfiguration configuration,
            IReportRepository reportRepository,
            IReportingAdapter reportingAdapter,
            IReportingAssembler reportAssembler,
            IReportGeneratorClient reportGeneratorClient)
        {
            _configuration = configuration;
            _logger = logger;
            _reportingAdapter = reportingAdapter;
            _reportAssembler = reportAssembler;
            _reportRepository = reportRepository;
            _reportGeneratorClient = reportGeneratorClient;
        }

        
        public async Task<Guid> CreateReportAsync(JsonElement reportParameters)
        {
            _logger.LogTrace($"\n[Orchestrator] [Method CreateReport]: Start");

            await Init(reportParameters);
            await CreateReportModel();
            await InitReportStructure();
            await GenerateReport();
            
            _logger.LogInformation($"[ReportId: {_reportId}]: End");
            _logger.LogTrace($"\n[Orchestrator] [Method CreateReport]:\n" +
                                   $"ReportId: {_reportId}\n" +
                                   $"End");

            return _reportGuidInGenerator;
        }
        
        public async Task<CustomFile> DownloadReportAsync(Guid reportGuid)
        {
            var reportDto = await _reportRepository.GetReportDtoByGuidReportInGenerator(reportGuid);
            var reportNameManager = ReportNameManagerHelper.GetReportNameManager(reportDto.TypeWithTemplateDto.Id);
            var reportName = reportNameManager.CreateReportName(new ReportNameManagerParameters()
            {
                ReportDto = reportDto
            });
            var extension = reportDto.TypeWithTemplateDto.ReportTypeDto.OutputFormat;
            var reportNameWithExtension = $"{reportName}.{extension}";

            var stream = await _reportGeneratorClient.DownloadReportAsync(reportGuid);

            return new CustomFile
            {
                Bytes = await stream.ToByteArrayAsync(),
                ContentType = System.Net.Mime.MediaTypeNames.Application.Octet,
                FileName = reportNameWithExtension
            };
        }

        public async Task<CustomFile> DownloadRawReportDataAsync(Guid reportGuid)
        {
            var reportDto = await _reportRepository.GetReportDtoByGuidReportInGenerator(reportGuid);
            var baseReportParams = JsonConvert.DeserializeObject<ReportParameters>(reportDto.Parameters);
            if (baseReportParams.DataFolder == null)
            {
                return null;
            }
            else
            {
                var foldersSection = _configuration.GetSection("Folders");
                var reportFolderPath = $"{foldersSection.GetSection("Tasks").Value}/{baseReportParams.DataFolder}";
                
                using (var memoryStream = new MemoryStream())
                {
                    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        archive.CreateEntryFromAny(reportFolderPath);
                    }
                    
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    
                    var reportNameManager = ReportNameManagerHelper.GetReportNameManager(reportDto.TypeWithTemplateDto.Id);
                    var reportName = reportNameManager.CreateReportName(new ReportNameManagerParameters()
                    {
                        ReportDto = reportDto
                    });
                    var reportNameWithExtension = $"{reportName}.zip";
                    return new CustomFile
                    {
                        Bytes = memoryStream.ToArray(),
                        ContentType = System.Net.Mime.MediaTypeNames.Application.Zip,
                        FileName = reportNameWithExtension
                    };
                }
            }
        }
        
        public async Task<CustomFile> DownloadRawReportWithDataAsync(Guid reportGuid)
        {
            var reportDto = await _reportRepository.GetReportDtoByGuidReportInGenerator(reportGuid);
            var reportNameManager = ReportNameManagerHelper.GetReportNameManager(reportDto.TypeWithTemplateDto.Id);
            var reportName = reportNameManager.CreateReportName(new ReportNameManagerParameters()
            {
                ReportDto = reportDto
            });
            var reportNameWithExtension = $"{reportName}.zip";

            var stream = await _reportGeneratorClient.DownloadReportWithDataAsync(reportGuid);
            
            return new CustomFile
            {
                Bytes = await stream.ToByteArrayAsync(),
                ContentType = System.Net.Mime.MediaTypeNames.Application.Zip,
                FileName = reportNameWithExtension
            };
        }

        private async Task Init(JsonElement reportParameters)
        {
            _logger.LogTrace($"\n[Orchestrator] [Method Init]: Start");

            try
            {
                var reportParametersJsonString = reportParameters.ToString();
                _reportParametersJson = reportParametersJsonString;
                try
                {
                    _baseReportParameters = JsonConvert.DeserializeObject<ReportParameters>(_reportParametersJson);
                }
                catch (Exception e)
                {
                    throw new InvalidCreateRequestJsonException();
                }
                var reportDto = await CreateReportInDbAsync(reportParametersJsonString);
                _reportId = reportDto.Id;

                

                
                InitDataFolder(_baseReportParameters);

                var reportFormatType = await _reportRepository.GetReportFormatByTypeWithTemplateId(_baseReportParameters.Type);
                _reportParameters = ReportParametersHelper.GetReportParameters(
                    reportFormatType,
                    await _reportRepository.GetReportTypeNumByReportTypeWithTemplateId(_baseReportParameters.Type),
                    _reportParametersJson);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"\n[Orchestrator] [Method Init]:\n" +
                                    $"Failed\n" +
                                    $"Message: {e.Message}\n" +
                                    $"StackTrace: {e.StackTrace}");
                throw;
            }

            
            _logger.LogInformation($"[ReportId {_reportId}]: Start");
            _logger.LogTrace($"\n[Orchestrator] [Method Init]: End");
        }

        private async Task<ReportDto> CreateReportInDbAsync(string reportParametersJsonString)
        {
            if (_baseReportParameters.Type == null || _baseReportParameters.CustomParameters == null)
            {
                throw new NullReportParametersException(_baseReportParameters.Type,
                    JsonConvert.SerializeObject(_baseReportParameters.CustomParameters));
            }
            if (!await _reportRepository.IsValidReportType(_baseReportParameters.Type))
            {
                throw new InvalidReportTypeException(_baseReportParameters.Type);
            }

            var report = await _reportRepository.CreateReportAsync(new CreateReportDto
            {
                TypeWithTemplateId = _baseReportParameters.Type,
                Parameters = reportParametersJsonString
            });

            return report;
        }

        private void InitDataFolder(ReportParameters reportParameters)
        {
            var foldersSection = _configuration.GetSection("Folders");
            try
            {
                _reportDataFolder = $"{foldersSection.GetSection("Tasks").Value}/{reportParameters.DataFolder}";
                //DeleteChartsFolder(_reportPaths.ReportDataFolder);
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        private async Task CreateReportModel()
        {
            _logger.LogTrace($"\n[Orchestrator] [Method CreateReportModel]:\n" +
                             $"ReportId: {_reportId}\n" +
                             $"Start");
            try
            {
                var formatId = await _reportRepository.GetReportFormatByTypeWithTemplateId(_reportParameters.Type);
                _reportingAdapter.Init(_reportParameters);
                _reportModel = await _reportingAdapter.CreateReportModel(
                    formatId,
                    _reportDataFolder,
                    _reportId);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"\n[Orchestrator] [Method CreateReportModel]:\n" +
                                    $"ReportId: {_reportId}\n" +
                                    $"Failed\n" +
                                    $"Message: {e.Message}\n" +
                                    $"StackTrace: {e.StackTrace}");
                throw;
            }
            
            _logger.LogTrace($"\n[Orchestrator] [Method CreateReportModel]:\n" +
                             $"ReportId: {_reportId}\n" +
                             $"End");
        }

        private async Task InitReportStructure()
        {
            _logger.LogTrace($"\n[Orchestrator] [Method InitReportStructure]:\n" +
                             $"ReportId: {_reportId}\n" +
                             $"Start");
            
            try
            {
                await _reportAssembler.InitReportStructure(
                    _reportModel,
                    _reportParameters,
                    _reportId);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"\n[Orchestrator] [Method InitReportStructure]:\n" +
                                    $"ReportId: {_reportId}\n" +
                                    $"Failed\n" +
                                    $"Message: {e.Message}\n" +
                                    $"StackTrace: {e.StackTrace}");
                throw;
            }
            
            _logger.LogDebug($"ReportId: {_reportId}\n" +
                             $"ReportModel: {JsonConvert.SerializeObject(_reportModel)}");

            _logger.LogTrace($"\n[Orchestrator] [Method InitReportStructure]:\n" +
                             $"ReportId: {_reportId}\n" +
                             $"End");
        }

        private async Task GenerateReport()
        {
            _logger.LogTrace($"\n[Orchestrator] [Method GenerateReport]:\n" +
                                   $"ReportId: {_reportId}\n" +
                                   $"Start");
            
            try
            {
                await SendCreateReportRequest();
            }
            catch (Exception e)
            {
                _logger.LogCritical($"\n[Orchestrator] [Method GenerateReport]:\n" +
                                    $"ReportId: {_reportId}\n" +
                                    $"Failed\n" +
                                    $"Message: {e.Message}\n" +
                                    $"StackTrace: {e.StackTrace}");
                throw;
            }
            
            _logger.LogTrace($"\n[Orchestrator] [Method GenerateReport]:\n" +
                                   $"ReportId: {_reportId}\n" +
                                   $"End");
            
        }

        private async Task SendCreateReportRequest()
        {
            _reportGuidInGenerator = await _reportGeneratorClient.CreateReportAsync(_reportModel);
            await _reportRepository.UpdateReportAsync(_reportId, new ReportDto
            {
                ReportGuidInGenerator = _reportGuidInGenerator
            });
        }

        private void DeleteChartsFolder(string reportDataFolderPath)
        {
            var chartsFolderPath = $"{reportDataFolderPath}/Charts";
            if (Directory.Exists(chartsFolderPath))
            {
                Directory.Delete(chartsFolderPath, true);
            }
        }
    }
}