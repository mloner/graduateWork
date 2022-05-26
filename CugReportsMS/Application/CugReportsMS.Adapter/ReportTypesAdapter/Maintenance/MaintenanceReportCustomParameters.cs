using System.Collections.Generic;
using CugReportMicroservice.Dtos;

namespace ReportingFramework.ReportTypesAdapter.Maintenance
{
    public class MaintenanceReportCustomParameters : CugReportMicroservice.Dtos.ReportingAdapterDataModels.CustomParameters
    {
        public GapPeriod MinGapPeriod { get; set; }
        public List<Cug> Cugs { get; set; }
    }

    public class Cug
    {
        public string CugGuid { get; set; }
        public List<string> InputGuids { get; set; }
    }
    
    // public class Building
    // {
    //     public string BuildingGuid { get; set; }
    //     public List<string> MeasurementGuids { get; set; }
    // }
    //
    
    public class GapPeriod
    {
        public int GapValue { get; set; }
        public PeriodType PeriodType { get; set; }
    }
    
}