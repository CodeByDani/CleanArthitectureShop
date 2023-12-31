using CleanArthitecture.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArthitecture.Presentation.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]  
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var (statusCode, message) = exception switch
            {
                IServiceException service => ((int)service.StatusCode,service.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError,"An Unhandled Error Occurred"),
            };
            return Problem(statusCode:statusCode,title:message);
        }
    }
}
