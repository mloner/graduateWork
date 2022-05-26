using EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions;

namespace CugReportMicroservice.Dtos.Exceptions.Init;

public class InvalidReportTypeException : DomainException
{
    public InvalidReportTypeException(int? reportType)
        : base($"Invalid report type. ReportType: {reportType}")
    {
    }
}