using CleanArthitecture.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArthitecture.Application.Services.Authentication
{
    public interface IAuthenticationServices
    {
        AuthenticationRespones Login(LoginRequest loginRequest);
        AuthenticationRespones Register(RegisterRequest registerRequest);

    }
}
