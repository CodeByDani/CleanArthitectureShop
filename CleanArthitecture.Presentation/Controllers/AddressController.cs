using CleanArthitecture.Application.Services.Address.Commands.AddAddress;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArthitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/address")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddressCommand address)
        {
            var result = await _mediator.Send(address);
            return Ok(result);
        }
    }
}
