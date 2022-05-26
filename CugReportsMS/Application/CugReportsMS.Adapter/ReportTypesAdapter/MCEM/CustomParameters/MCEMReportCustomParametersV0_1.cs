using System.Collections.Generic;

namespace ReportingFramework.ReportTypesAdapter.MCEM.CustomParameters
{
    public class MCEMReportCustomParametersV0_1 : CugReportMicroservice.Dtos.ReportingAdapterDataModels.CustomParameters
    {
        public int RefYear { get; set; }
        public int CurYear { get; set; }
        
        public List<string> Cugs { get; set; }
    }
}