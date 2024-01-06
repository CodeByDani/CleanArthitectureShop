using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Application.DTO;
using CleanArthitecture.Application.Services.Order.Commands.AddOrder;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.OrderItem.Commands.AddRangeOrderItem
{
    public class AddRangeOrderItemCommandHandler : IRequestHandler<AddRangeOrderItemCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMediator _mediator;
        public AddRangeOrderItemCommandHandler(IProductRepository productRepository, IUnitOfWork uow,
            IMapper mapper, IMediator mediator, IOrderItemRepository orderItemRepository)
        {
            _productRepository = productRepository;
            _uow = uow;
            _mapper = mapper;
            _mediator = mediator;
            _orderItemRepository = orderItemRepository;
        }
        public async Task Handle(AddRangeOrderItemCommand command, CancellationToken cancellationToken)
        {
            List<OrderItemDTO> orderDtoItems = new List<OrderItemDTO>();
            for (int i = 0; i < command.ProductId.Count; i++)
            {
                var product = _productRepository.FindByIdAsync(command.ProductId.ElementAt(i)).Result;
                var count = command.Quantity.ElementAt(i);

                orderDtoItems.Add(new OrderItemDTO(
                    TotalPrice: product.Price * count,
                    ProductId: product.Id,
                    Quantity: count
                    ));
            }
            var amount = orderDtoItems.Sum(o => o.TotalPrice);

            var orderId = await _mediator.Send(new AddOrderCommand(
                CustomerId: command.CustomerId,
                Amount: amount
            ));
            var result = _mapper.Map<List<Domain.Entities.OrderItem>>(orderDtoItems);
            result.ForEach(o => o.OrderId = orderId);
            _orderItemRepository.AddRange(result);
            await _uow.SaveAsync();

        }
    }
}
