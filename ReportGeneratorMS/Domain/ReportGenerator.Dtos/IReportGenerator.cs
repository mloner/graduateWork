using System;
using System.Collections.Generic;
using System.Text.Json;
using ReportingFramework.Dto.DataModels;

namespace ReportingFramework.Dto
{
    public interface IReportGenerator
    {
        ReportModelExtended ReportModel { get; set; }
        ReportSettings Settings { get; set; }
        INumberFormatter NumberFormatter { get; set; }
        List<IReportSection> ReportSections { get; set; }
        string _reportPath { get; set; }
        
        
        void Init(JsonElement reportStructureJson, Guid reportGuid);
        void Generate();
        void Open();
    }
}