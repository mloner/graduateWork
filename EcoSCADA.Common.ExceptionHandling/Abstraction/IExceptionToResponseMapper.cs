using System;
using EcoSCADA.Common.ExceptionHandling.Models;

namespace EcoSCADA.Common.ExceptionHandling.Abstraction
{
    internal interface IExceptionToResponseMapper
    {
        ExceptionResponse Map(Exception exception, ProblemDetailsExtensions extensions);
    }
}