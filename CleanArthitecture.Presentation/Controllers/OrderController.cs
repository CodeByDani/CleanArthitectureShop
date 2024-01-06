using CleanArthitecture.Application.Services.OrderItem.Commands.AddRangeOrderItem;
using CleanArthitecture.Presentation.DTO;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArthitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/order")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OrdersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(HashSet<OrderRequest> request)
        {
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var orderItems = _mapper.Map<AddRangeOrderItemCommand>(request);
            orderItems.CustomerId = Convert.ToInt64(customerId);
            await _mediator.Send(orderItems);

            return StatusCode(201, "Order Added Successfully");
        }

    }

}
