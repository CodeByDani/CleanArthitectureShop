using System.Net;

namespace CleanArthitecture.Application.Common.Errors;

public class EmptyProductException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "Product Doesn't Exists";
}