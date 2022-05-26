using System.ComponentModel;

namespace CugReportMicroservice.Dtos.ReportTypeEnums
{
    public enum ExcelReportTypeEnum
    {
        [Description("MaintenanceReport")]
        MaintenanceReport = 1,
        
        [Description("MCEM")]
        MCEM = 2,
        
        [Description("CugSavingsReport")]
        CugSavingsReport = 3,
        
        [Description("DQValidReport")]
        DQValidReport = 5
    }
}