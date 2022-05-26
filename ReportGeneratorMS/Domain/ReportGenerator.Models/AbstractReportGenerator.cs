using System.Diagnostics;
using System.Text.Json;
using ChartGeneratorClient;
using GeneratorDataBase;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using ReportingFramework.Common;
using ReportingFramework.Common.TemplateLoader;
using ReportingFramework.Dto;
using ReportingFramework.Dto.DataModels;

namespace SectionModels
{
    public abstract class AbstractReportGenerator : IReportGenerator
    {
        protected Guid _reportGuid;
        private IReportGeneratorRepository _reportGeneratorRepository;
        private IChartGeneratorClient _chartGeneratorClient;
        public readonly IConfiguration Configuration;
        
        public AbstractReportGenerator(
            IReportGeneratorRepository reportGeneratorRepository,
            IChartGeneratorClient chartGeneratorClient,
            IConfiguration configuration)
        {
           // Paths = paths;
           ReportSections = new List<IReportSection>();
           _reportGeneratorRepository = reportGeneratorRepository;
           _chartGeneratorClient = chartGeneratorClient;
           Configuration = configuration;
        }

        
        public ReportModelExtended ReportModel { get; set; }
        public ReportSettings _settings;
        public ReportSettings Settings
        {
            get => _settings;
            set => _settings = value;
        }
        public INumberFormatter NumberFormatter { get; set; }
        public List<IReportSection> ReportSections { get; set; }
        public string _reportPath { get; set; }
        
        
        public virtual void Init(JsonElement reportStructureJson, Guid reportGuid)
        {
            _reportGuid = reportGuid;
            InitReportModel(reportStructureJson);
            InitTemplate();
            InitReportPaths();
            InitNumberFormatter();
            InitChartGenerator();
            AddReportSections(reportStructureJson);
        }

        public abstract void InitReportModel(JsonElement reportStructureJson);
        public virtual void InitReportPaths()
        {
            var paths = new ReportPaths();
            ReportModel.Paths = new ReportPaths();

            var root = AppDomain.CurrentDomain.BaseDirectory;
            root = root.Substring(0, root.Length - 1);
            paths.Root = root;
            
            paths.Data = $"{root}/Data";
            
            //common
           paths.CommonResources = $"{paths.Data}/CommonResources";
           paths.CommonResourcesImages = $"{paths.CommonResources}/Images";
           paths.CommonResourcesLogos = $"{paths.CommonResourcesImages}/Logos";
           paths.TextResourceNameSpaceTemplate = "ReportingFramework.Common.Data.SectionsResources.[resName].TextResources.Res";
            
            //excel
            paths.ExcelTemplates = $"{paths.CommonResources}/ExcelTemplates";
            paths.OutputFolder = $"{paths.Data}/Reports";
            
            if (!Directory.Exists(paths.OutputFolder))
            {
                Directory.CreateDirectory(paths.OutputFolder);
            }
            

            if (ReportModel.Template?.GlobalSettings?.CompanyName != null)
            {
                //company
                paths.CompanyImages =
                    $"{paths.CommonResourcesImages}/Companies/{ReportModel.Template.GlobalSettings.CompanyName}";
                paths.CompanyBackgrounds = $"{paths.CompanyImages}/Backgrounds";
            }
            
            
            //charts
            paths.ReportCharts = $"{paths.OutputFolder}/{_reportGuid}";

           ReportModel.Paths = paths;
        }
        public virtual void InitTemplate()
        {
            ReportModel.Template = TemplateLoaderHelper
                    .GetTemplateLoader(ReportModel.ReportFormat)
                    .LoadTemplate(_reportGeneratorRepository.GetTemplateById(ReportModel.TemplateId).Result.TemplateFull);
        }
        public virtual void InitNumberFormatter()
        {
            ReportModel.NumberFormatter = new NumberFormatter
            {
                GroupSeparator = ReportModel.Template.GlobalSettings.ThousandsSeparator,
                DecimalSeparator = ReportModel.Template.GlobalSettings.DecimalSeparator,
                NullValue = "-"
            };
        }
        public virtual void InitChartGenerator()
        {
            // ReportModel.ChartGeneratorClient = new global::ChartGeneratorClient.ChartGeneratorClient();
            // ReportModel.ChartGeneratorClient.Init(new ChartGeneratorSettings
            // {
            //     ServerAddress = Configuration
            //         .GetSection("Api")
            //         .GetSection("Microservices")
            //         .GetSection("ChartGenerator")
            //         .GetSection("Url")
            //         .Value,
            //     ApiKey = null
            // });
        }
        public void AddReportSections(JsonElement reportStructureJson)
        {
            var jo = JObject.Parse(reportStructureJson.ToString());
            var sections = jo["Sections"].ToList();
            foreach (var jTokenSection in sections)
            {
                AddSection(jTokenSection);
            }
        }
        public abstract void AddSection(JToken jTokenSection);
        public abstract void Generate();
        public virtual void Open()
        {
            Process p = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = _reportPath
                }
            };
            p.Start();
        }
    }
}