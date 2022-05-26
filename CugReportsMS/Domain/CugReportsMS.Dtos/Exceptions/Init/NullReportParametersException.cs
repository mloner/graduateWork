using EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions;

namespace CugReportMicroservice.Dtos.Exceptions.Init;

public class NullReportParametersException : DomainException
{
    public NullReportParametersException(int? reportType, string? reportParameters)
        : base($"One of the parameters (or both) is null. ReportType: {reportType}, CustomParameters: {reportParameters}")
    {
    }
}