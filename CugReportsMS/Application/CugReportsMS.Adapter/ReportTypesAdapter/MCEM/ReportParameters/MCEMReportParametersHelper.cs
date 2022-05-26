using System;
using Newtonsoft.Json;

namespace ReportingFramework.ReportTypesAdapter.MCEM.ReportParameters
{
    public class MCEMReportParametersHelper : IReportParametersHelper
    {
        public CugReportMicroservice.Dtos.ReportingAdapterDataModels.ReportParameters GetReportParameters(double reportVersion, string json)
        {
            switch (reportVersion)
            {
                case 0.1:
                    return JsonConvert.DeserializeObject<MCEMReportParametersV0_1>(json);
                
                default:
                    throw new Exception();
            }
        }
        
    }
}