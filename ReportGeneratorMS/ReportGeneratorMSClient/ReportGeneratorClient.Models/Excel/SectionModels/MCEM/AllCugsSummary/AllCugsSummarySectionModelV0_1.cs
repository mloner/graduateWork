using SectionModels.ReportObjects.Tables;

namespace SectionModels.Excel.SectionModels.MCEM.AllCugsSummary;

public class AllCugsSummarySectionModelV0_1 : AllCugsSummarySectionModel
{
    public AllCugsSummaryTable AllCugsSummaryTable { get; set; }
    public AllCugsSummarySectionModelV0_1()
    {
        //Version = 0.1;
    }
}