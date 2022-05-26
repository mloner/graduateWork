using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using ChartGeneratorClient;
using ClosedXML.Excel;
using ExcelGenerator.Structure;
using GeneratorDataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReportingFramework.Common.Extentions;
using ReportingFramework.Common.TemplateLoader;
using ReportingFramework.Dto;
using SectionModels;
using ExcelReportModel = ExcelGenerator.Structure.ExcelReportModel;

namespace ExcelGenerator
{
    public class ExcelReportGenerator : AbstractReportGenerator
    {
        private readonly ILogger<ExcelReportGenerator> _logger;
        
        public ExcelReportGenerator(IReportGeneratorRepository reportGeneratorRepository,
            IChartGeneratorClient chartGeneratorClient,
            IConfiguration configuration,
            ILogger<ExcelReportGenerator> logger
            ) : base(reportGeneratorRepository,
                chartGeneratorClient,
                configuration)
        {
            _logger = logger;
        }
        
        public override void InitReportModel(JsonElement reportStructureJson)
        {
            ReportModel = JsonConvert.DeserializeObject<ExcelReportModel>(reportStructureJson.ToString());
        }

        public override void AddSection(JToken jTokenSection)
        {
            var joSectionModel = JObject.Parse(jTokenSection.ToString());
            var sec = ExcelSectionHelper.GetSection(int.Parse(joSectionModel["Subtype"].ToString()));
            //var sec = secHelper.GetSection(double.Parse(joSectionModel["Version"].ToString()));
            sec.InitSectionModel(joSectionModel.ToString());
            ReportSections.Add(sec);
        }

        public override void Generate()
        {
            _logger.LogTrace($"\n[ExcelReportGenerator] [Method Generate]: Start");
            
            FileInfo outputFile = new FileInfo($"{ReportModel.Paths.OutputFolder}/{_reportGuid}.{ReportModel.OutputFormat}");
            var workbook = new XLWorkbook();

            foreach (var reportSection in ReportSections.Select(x => x as ExcelReportSection))
            {
                reportSection.Init(new ExcelSectionParameters()
                {
                    OutWorkbook = workbook,
                    Paths = ReportModel.Paths,
                    Template = (ExcelTemplate)ReportModel.Template,
                    NumFmtr = ReportModel.NumberFormatter,
                    ResourceParameters = new ResourceParameters()
                    {
                        CultureInfo = new CultureInfo(((ReportLanguageEnum)ReportModel.LanguageId).Desc())
                    }
                    //ChartGeneratorClient = ReportModel.ChartGeneratorClient
                });
                reportSection.Generate();
            }
            
            workbook.SaveAs(outputFile.FullName, validate: false);
            workbook.Dispose();
            
            _reportPath = outputFile.FullName.Replace("\\", "/");
            
            _logger.LogTrace($"\n[ExcelReportGenerator] [Method Generate]: End");
        }
    }
}