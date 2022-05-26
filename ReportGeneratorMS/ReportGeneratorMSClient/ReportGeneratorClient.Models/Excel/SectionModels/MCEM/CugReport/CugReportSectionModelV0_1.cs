using SectionModels.ReportObjects.Tables;

namespace SectionModels.Excel.SectionModels.MCEM.CugReport;

public class CugReportSectionModelV0_1 : CugReportSectionModel
{
    public CugReportTable CugReportTable { get; set; }
    public CugReportSectionModelV0_1()
    {
        //Version = 0.1;
    }
}