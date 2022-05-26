using ReportConfigurationMS.Domain;

namespace Worker;

public static class ReportNextGenerationDateTimeHelper
{
    public static DateTime GetNextGenerationDateTime(DateTime now, ReportFrequency reportFrequency)
    {
        var resultDateTime = now.Date;
        switch (reportFrequency)
        {
            case ReportFrequency.Daily:
                resultDateTime = resultDateTime.AddDays(1);
                break;
            case ReportFrequency.Weekly:
                resultDateTime = resultDateTime.AddDays(7);
                break;
            case ReportFrequency.Monthly:
                resultDateTime = resultDateTime.AddMonths(1);
                break;
            case ReportFrequency.FirstMondayOfMonth:
                var nextMonthsDateTime = resultDateTime.AddMonths(1);
                resultDateTime = new DateTime(nextMonthsDateTime.Year, nextMonthsDateTime.Month, 1);
                break;
            case ReportFrequency.Quarterly:
                int quarterNumber = (resultDateTime.Month - 1) / 3 + 1;
                resultDateTime = new DateTime(resultDateTime.Year, (quarterNumber - 1 ) * 3 + 1, 1);
                break;
            default: throw new Exception("GetNextGenerationDateTime");
        }

        resultDateTime = resultDateTime.AddHours(5);
        return resultDateTime;
    }
}