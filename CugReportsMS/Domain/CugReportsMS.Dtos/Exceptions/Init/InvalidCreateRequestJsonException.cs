using EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions;

namespace CugReportMicroservice.Dtos.Exceptions.Init;

public class InvalidCreateRequestJsonException : DomainException
{
    public InvalidCreateRequestJsonException()
        : base($"Invalid request json")
    {
    }
}