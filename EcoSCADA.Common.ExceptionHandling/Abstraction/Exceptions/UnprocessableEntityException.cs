using System;

namespace EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions
{
    public abstract class UnprocessableEntityException: Exception
    {
        protected UnprocessableEntityException(string message): base(message)
        {
        }
    }
}