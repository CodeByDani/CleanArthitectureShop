using System.Net;

namespace CleanArthitecture.Application.Common.Errors;

public class LoginError : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
    public string ErrorMessage => "User Or Password Incorrect";
}