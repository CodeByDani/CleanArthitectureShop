using System.Net;

namespace CleanArthitecture.Application.Common.Errors
{
    public class DuplicateEmailException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Forbidden;

        public string ErrorMessage => "Email already Exist";
    }
}