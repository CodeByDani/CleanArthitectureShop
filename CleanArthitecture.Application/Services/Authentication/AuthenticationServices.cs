using CleanArthitecture.Application.Common.Interfaces.Authentication;


namespace CleanArthitecture.Application.Services.Authentication
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IJwtTokenGenerator _jwtToken;

        public AuthenticationServices(IJwtTokenGenerator jwtToken)
        {
            _jwtToken = jwtToken;
        }

        public AuthenticationRespones Login(LoginRequest loginRequest)
        {
            return new AuthenticationRespones
            (1,"firstname","lastname",loginRequest.UserName,"token");
        }

        public AuthenticationRespones Register(RegisterRequest registerRequest)
        {
            var customerId = 1;
            var token = _jwtToken.GenerateToken(customerId,"","");
            return new AuthenticationRespones
            (1, registerRequest.FirstName, registerRequest.LastName, registerRequest.UserName, token);
        }
    }
}
