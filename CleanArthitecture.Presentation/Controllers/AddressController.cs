using CleanArthitecture.Application.Services.Address.Commands.AddAddress;
using CleanArthitecture.Presentation.DTO;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArthitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/address")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AddressController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddressRequest address)
        {
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var addressResult = _mapper.Map<AddressCommand>(address);
            addressResult = addressResult with { CustomerId = Convert.ToInt64(customerId) };

            var result = await _mediator.Send(addressResult);
            return Ok(result);
        }
    }
}
