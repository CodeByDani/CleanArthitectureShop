using CleanArthitecture.Application.Services.Authentication;
using CleanArthitecture.Domain.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CleanArthitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _auth;
        public AuthenticationController(IAuthenticationServices auth)
        {
            _auth = auth;
        }
        //!Register
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
           var authResult = _auth.Register(request);
            return Ok(authResult);
        }
        //! Login
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request) {
            var authResult = _auth.Login(request);
            return Ok(authResult); 
        }
    }
}
