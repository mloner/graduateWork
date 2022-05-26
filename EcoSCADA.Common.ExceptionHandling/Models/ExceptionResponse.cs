using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EcoSCADA.Common.ExceptionHandling.Models
{
    public class ExceptionResponse : ProblemDetails
    {
        public string StackTrace { get; set; }
        public IDictionary<string, object> Errors { get; set; }
    }
}