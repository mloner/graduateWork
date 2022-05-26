namespace ReportingFramework.ReportTypesAdapter.MCEM.DataModels
{
    public class MECMReportDataModel
    {
        public string CugName { get; set; }
        public string BuildingName { get; set; }
        public string BuildingType { get; set; }
        
        public double? Surface { get; set; }
        
        public double? ElectricityCurrentYear { get; set; }
        public double? ElectricityRefYear { get; set; }
        
        public double? GasCurrentYear { get; set; }
        public double? GasRefYear { get; set; }
        
        public double? SolarCurrentYear { get; set; }
        public double? SolarRefYear { get; set; }
    }
}