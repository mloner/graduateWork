namespace CugReportMicroservice.Dtos
{
    public static class PeriodTypeExtension
    {
        public static int PeriodToMinutes(int value, PeriodType periodType)
        {
            var newValue = value;
            switch (periodType)
            {
                case PeriodType.Year:
                    newValue *= 365 * 12 * 30 * 24 * 60;
                    break;
                case PeriodType.Month:
                    newValue *= 12 * 30 * 24 * 60;
                    break;
                case PeriodType.Week:
                    newValue *= 7 * 24 * 60;
                    break;
                case PeriodType.Day:
                    newValue *= 24 * 60;
                    break;
                case PeriodType.Hour:
                    newValue *= 60;
                    break;
                case PeriodType.Minute:
                    break;
            }

            return newValue;
        }
    }
}