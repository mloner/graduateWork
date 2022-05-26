using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using ChartGeneratorClient;
using ChartGeneratorModels;
using ChartGeneratorModels.ChartGeneratorModels;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SectionModels;

namespace ReportAssembler
{
    public class ReportAssembler : IReportingAssembler
    {
        private IReportRepository _reportRepository;
        private IChartGeneratorClient _chartGeneratorClient;
        private ReportModel _reportModel;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ReportAssembler> _logger;


        public ReportAssembler(
            ILogger<ReportAssembler> logger,
            IReportRepository reportRepository,
            IChartGeneratorClient chartGeneratorClient,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _reportRepository = reportRepository;
            _chartGeneratorClient = chartGeneratorClient;
        }

        public async Task InitReportStructure(ReportModel reportModel, ReportParameters reportParameters, int reportId)
        {
            _reportModel = reportModel;
            _reportModel.ReportFormat = (ReportFormatEnum)(await _reportRepository.GetReportFormatByTypeWithTemplateId(reportParameters.Type));
            _reportModel.OutputFormat = await _reportRepository.GetReportOutputFormatByTypeWithTemplateId(reportParameters.Type);
            _reportModel.LanguageId = (await _reportRepository.GetReportLanguageByTypeWithTemplateId(reportParameters.Type)).Value;
            _reportModel.TemplateId = int.Parse(await _reportRepository.GetTemplateIdByReportTypeWithTemplateId(reportParameters.Type));
            
            foreach (var reportModelSection in _reportModel.Sections)
            {
                await DownloadCharts(reportModelSection);
            }
        }

        private async Task DownloadCharts(object obj)
        {
            if (obj == null)
            {
                return;
            }
            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            object propValue = null;
            
            foreach (PropertyInfo prop in props)
            {
                if (prop.PropertyType.ToString().StartsWith("System."))
                {
                    continue;
                }
                propValue = prop.GetValue(obj, null);
                if (prop.PropertyType.ToString() == (new ChartRequestDataBase()).GetType().ToString() && propValue != null)
                {
                    var chart = (ChartRequestData)propValue;
                    chart.ChartSettings.Language = (ChartLanguage)_reportModel.LanguageId;
                    var chartJson = JsonConvert.SerializeObject(propValue as ChartRequestData);
                    prop.SetValue(obj, new ChartRequestDataBase()
                    {
                        Url = await _chartGeneratorClient.CreateChartAsync(propValue as ChartRequestData)
                    });
                }
                else
                {
                    await DownloadCharts(propValue);
                }
            }
        }

    }
}