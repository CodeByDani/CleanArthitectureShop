using CleanArthitecture.Application.Authentication.Commands.Register;
using CleanArthitecture.Application.Authentication.Queries;
using CleanArthitecture.Presentation.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArthitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //!Register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            var authResult = await _mediator.Send(command);
            return authResult.MatchFirst(

                authResult => Ok(authResult),
                err => Problem(statusCode: StatusCodes.Status409Conflict, title: err.Description)
            );
        }
        //! Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            var authResult = await _mediator.Send(query);
            return Ok(authResult);
        }
    }
}
