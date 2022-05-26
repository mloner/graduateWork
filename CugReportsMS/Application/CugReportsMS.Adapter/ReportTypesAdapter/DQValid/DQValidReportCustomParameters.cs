using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using ReportingFramework.ReportTypesAdapter.DQValid.DataModels;

namespace ReportingFramework.ReportTypesAdapter.DQValid
{
    public class DQValidReportCustomParameters : CustomParameters
    {
        public DQInputData Data { get; set; }
    }
}