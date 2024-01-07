using CleanArthitecture.Application.Services.OrderItem.Commands.AddRangeOrderItem;
using CleanArthitecture.Presentation.DTO;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CleanArthitecture.Application.Services.Payment.Commands;
using Microsoft.AspNetCore.Authorization;

namespace CleanArthitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/payment")]
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PaymentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> InitPayment([FromForm]PaymentRequest request)
        {
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var payment = _mapper.Map<AddPaymentCommand>(request);
            payment = payment with
            {
                CustomerId = Convert.ToInt64(customerId),
                DateTime = DateTime.Now
            };
            await _mediator.Send(payment);

            return StatusCode(201, "Payment Work Fine");
        }
    }
}
