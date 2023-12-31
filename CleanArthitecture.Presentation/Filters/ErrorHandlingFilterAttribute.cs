﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArthitecture.Presentation.Filters
{
    public class ErrorHandlingFilterAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1", 
                Status = Convert.ToInt32(HttpStatusCode.InternalServerError),
                Title = exception.Message
            };
            context.Result = new ObjectResult(problemDetails);
            context.ExceptionHandled = true;
            
        }
    }
}
