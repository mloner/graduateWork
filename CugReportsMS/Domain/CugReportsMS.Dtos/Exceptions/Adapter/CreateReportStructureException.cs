using EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions;

namespace CugReportMicroservice.Dtos.Exceptions.Adapter;

public class CreateReportStructureException : DomainException
{
    public CreateReportStructureException()
        : base($"Failed to create report structure")
    {
        
    }
}