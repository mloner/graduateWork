namespace SectionModels.ReportObjects.Tables;

public class CugReportTable : Table
{
    public new List<CugSectionTableDataItem> Data { get; set; }
    public class CugSectionTableDataItem
    {
        public string BuildingName { get; set; }
        public string BuildingType { get; set; }
        
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