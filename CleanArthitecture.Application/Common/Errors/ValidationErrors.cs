using System.Net;

namespace CleanArthitecture.Application.Common.Errors
{
    public class ValidationErrors(string message) : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public string ErrorMessage { get; } = message;

    }

}