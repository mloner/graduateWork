using CugReportMicroservice.Dtos.ReportTypeEnums;
using ReportNameManager.ReportNameManagers;

namespace ReportNameManager;

public static class ReportNameManagerHelper
{
    public static ReportNameManagers.ReportNameManager GetReportNameManager(int reportTypeWithTemplate)
    {
        switch ((ReportTypeWithTemplateEnum)reportTypeWithTemplate)
        {
            case ReportTypeWithTemplateEnum.AlgoComp_Jabba:
                return new AlgoCompReportNameManager();
            default:
                return new ReportNameManagers.ReportNameManager();
        }
    }
}