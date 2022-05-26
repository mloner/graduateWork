namespace ReportConfigurationMS.Domain.ReportParameters;

public class MaintenanceReportCustomParameters
{
    public MinGapsPeriod MinGapPeriod { get; set; }
    public List<Cug> Cugs { get; set; }
}

public class MinGapsPeriod
{
    public int GapValue { get; set; }
    public int PeriodType { get; set; }
}

public class Cug
{
    public Guid CugGuid { get; set; }
    public List<Guid> InputGuids { get; set; }
}