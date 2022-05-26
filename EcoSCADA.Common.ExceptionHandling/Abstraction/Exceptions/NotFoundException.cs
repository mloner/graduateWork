using System;
using System.Collections.Generic;

namespace EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        public IDictionary<string, object> Errors;

        protected NotFoundException(string message) : base(message)
        {
        }

        protected NotFoundException(string message, IDictionary<string, object> errors) : base(message)
        {
            Errors = errors;
        }
    }
}