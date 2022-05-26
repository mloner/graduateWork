using System;
using System.Collections.Generic;

namespace EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions
{
    public abstract class DomainException : Exception
    {
        //For more detailed error information
        public IDictionary<string,object> Errors;
        protected DomainException(string message): base(message)
        {
        }
        
        protected DomainException(string message, IDictionary<string, object> errors): base(message)
        {
            Errors = errors;
        }
    }
}