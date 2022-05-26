﻿namespace CugReportMicroservice.Dtos.ExcelSectionData.MultiCugReportEnergyManagementReport.AllCugsSummarySection
{
    public class CugsSummarySectionTableDataItem
    {
        public string CugName { get; set; }
        public double? Surface { get; set; }
        
        public double? ElectricityCurrentYear { get; set; }
        public double? ElectricityRefYear { get; set; }
        public double? ElectricityKpi { get; set; }
        
        public double? GasCurrentYear { get; set; }
        public double? GasRefYear { get; set; }
        public double? GasKpi { get; set; }
        
        public double? SolarCurrentYear { get; set; }
        public double? SolarRefYear { get; set; }
        public double? SolarKpi { get; set; }
    }
}