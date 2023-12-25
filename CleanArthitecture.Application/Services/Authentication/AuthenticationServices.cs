using CleanArthitecture.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArthitecture.Application.Services.Authentication
{
    public class AuthenticationServices : IAuthenticationServices
    {
        public AuthenticationRespones Login(LoginRequest loginRequest)
        {
            return new AuthenticationRespones
            (1,"firstname","lastname",loginRequest.UserName,"token");
        }

        public AuthenticationRespones Register(RegisterRequest registerRequest)
        {
            return new AuthenticationRespones
            (1, registerRequest.FirstName, registerRequest.LastName, registerRequest.UserName, "token");
        }
    }
}
