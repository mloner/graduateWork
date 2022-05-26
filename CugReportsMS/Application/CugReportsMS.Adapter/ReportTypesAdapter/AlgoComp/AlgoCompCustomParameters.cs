namespace ReportingFramework.ReportTypesAdapter.AlgoComp
{
    public class AlgoCompCustomParameters : CugReportMicroservice.Dtos.ReportingAdapterDataModels.CustomParameters
    {
        public string BuildingName { get; set; }
        public string BatteryModel { get; set; }
        public double BatteryCapacity { get; set; }
        public string Email { get; set; }
    }
}