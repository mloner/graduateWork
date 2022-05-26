using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using ChartGeneratorClient;
using GeneratorDataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PdfReportTemplaterClient;
using ReportingFramework.Common.Extentions;
using ReportingFramework.Dto;
using ReportingFramework.Structure;
using ReportingFramework.Structure.SectionHelpers;
using SectionModels;
using SectionModels.Pdf;

namespace ReportingFramework
{
    public class PdfReportGenerator : AbstractReportGenerator
    {
        private readonly IPdfReportTemplaterClient _pdfReportTemplaterClient;
        private JObject reportModelJobject;
        private readonly ILogger<PdfReportGenerator> _logger;

        public PdfReportGenerator(IReportGeneratorRepository reportGeneratorRepository,
            IChartGeneratorClient chartGeneratorClient,
            IConfiguration configuration,
            IPdfReportTemplaterClient pdfReportTemplaterClient,
            ILogger<PdfReportGenerator> logger
        ) : base(reportGeneratorRepository,
                chartGeneratorClient,
                configuration)
        {
           _pdfReportTemplaterClient = pdfReportTemplaterClient;
           _logger = logger;
        }
        
       public override void InitReportModel(JsonElement reportStructureJson)
       {
           ReportModel = JsonConvert.DeserializeObject<PdfReportModelExtended>(reportStructureJson.ToString());
       }
       
       public override void AddSection(JToken jTokenSection)
       {
           var joSectionModel = JObject.Parse(jTokenSection.ToString());
           var secHelper = PdfSectionHelperHelper.GetSectionHelper(int.Parse(joSectionModel["Subtype"].ToString()));
           var sec = secHelper.GetSection(double.Parse(joSectionModel["Version"].ToString()));
           sec.InitSectionModel(joSectionModel.ToString());
           //sec.InitResName();
           ReportSections.Add(sec);
       }

       public override void Init(JsonElement reportStructureJson, Guid reportGuid)
       {
           _reportGuid = reportGuid;
           InitReportModel(reportStructureJson);
           InitReportPaths();
           reportModelJobject = JObject.Parse(reportStructureJson.ToString());
       }

       public override void Generate()
       {
           _logger.LogTrace($"\n[PdfReportGenerator] [Method Generate]: Start");
           
           var dataModel = ConvertSectionListToDictionary(reportModelJobject["Sections"]);
           
           _logger.LogDebug($"\nReportGuid: {_reportGuid}\n" +
                            $"DataModel: {dataModel}");
           _logger.LogTrace($"\n[PdfReportGenerator] [Method Generate]:\n" +
                                  $"ReportGuid: {_reportGuid}\n" +
                                  $"DataModel: {dataModel}");

           var templateId = int.Parse(reportModelJobject["TemplateId"].ToString());
           //var dataModelJson = JsonConvert.SerializeObject(dataModel);
           var reportBase64 = _pdfReportTemplaterClient.CreateReportAsync(dataModel, templateId).Result;
           var bytes = Convert.FromBase64String(reportBase64);
           var filePath = $"{ReportModel.Paths.OutputFolder}/{_reportGuid}.{ReportModel.OutputFormat}";
           var stream = new FileStream(filePath, FileMode.CreateNew);
           var writer = new BinaryWriter(stream);
           writer.Write(bytes, 0, bytes.Length);
           writer.Close();

           _reportPath = filePath;
           
           _logger.LogTrace($"\n[PdfReportGenerator] [Method Generate]: End");
       }

       private JObject ConvertSectionListToDictionary(JToken sections)
       {
           var dataModel = new JObject();
           foreach (var jTokenSection in sections)
           {
               dataModel.Add(
                   ((PdfSectionEnum)int.Parse(jTokenSection["Subtype"].ToString()))
                   .Desc()
                   .Split("_")
                   .Skip(1)
                   .FirstOrDefault(),
                   jTokenSection);
           }

           return dataModel;
       }
    }
}