using System;
using System.Collections.Generic;
using System.IO;
using ChartGeneratorModels;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReportingFramework.DataModels.CustomerData;
using ReportingFramework.SectionAdapter;
using SectionModels;
using SectionModels.Pdf;

namespace ReportingFramework.ReportAdapter
{
    public class PdfReportAdapter : ReportAdapter
    {
        public new PdfReportModel ReportModel { get; set; }
        public List<PdfSectionEnum> PdfSections { get; set; }
        public PdfReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportAdapter>  logger)
            : base(reportAdapterParameters, reportRepository, logger)
        {
            ReportModel = new PdfReportModel()
            {
                Sections = new List<SectionModel>()
            };
        }

        protected override void InitCommonReportData()
        {
        }

        protected override ReportModel InitReportStructure()
        {
            var sectionAdapterHelper = new SectionAdapterHelper();
            
            foreach (var sectionEnum in PdfSections)
            {
                try
                {
                    var sectionAdapter = sectionAdapterHelper.GetSectionAdapter(
                        ReportFormatEnum.Pdf,
                        (int)sectionEnum);

                    sectionAdapter.Init(new SectionArgs
                    {
                        ReportCommonData = ReportCommonData,
                        ReportAdapterParameters = ReportAdapterParameters,
                        CsvReader = CsvReader
                    });
                    sectionAdapter.LoadData();
                    var section = sectionAdapter.CreateSectionModel();


                    ReportModel.Sections.Add(section);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Section: " + sectionEnum.Desc());
                    throw;
                }
            }


            return ReportModel;
        }
        

        public dynamic ParamsJson;
        public void GetparamsJson()
        {
            using (StreamReader r = new StreamReader($"{ReportAdapterParameters.ReportDataFolderPath}/params.json"))
            {
                string json = r.ReadToEnd();
                ParamsJson = JObject.Parse(json);
            }
            ReportCommonData.Add("Params", ParamsJson);
        }
        
        public void GetCustomerData()
        {
            using (StreamReader r = new StreamReader(
                       $"{ReportAdapterParameters.ReportDataFolderPath}/customerData.json"))
            {
                string json = r.ReadToEnd();
                var customerData = JsonConvert.DeserializeObject<CustomerData>(json);
                ReportCommonData.Add("CustomerData", customerData);
            }
        }
    }
}