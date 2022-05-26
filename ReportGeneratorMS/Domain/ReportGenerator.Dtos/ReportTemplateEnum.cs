using System.ComponentModel;

namespace ReportingFramework.Dto
{
    public enum ReportTemplateEnum
    {
        [Description("Excel_Default")]
        Excel_Default = 1,
        
        [Description("MaintenanceReport_Default")]
        MaintenanceReport_Default = 2,
        
        [Description("MultiCugEnergyManagementReport_Default")]
        MultiCugEnergyManagementReport_Default = 3,
        
        [Description("CugSavingsReport_Default")]
        CugSavingsReport_Default = 4,
    }
}