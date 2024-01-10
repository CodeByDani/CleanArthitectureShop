using CleanArthitecture.Application.Common.Errors;
using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Application.DTO;
using CleanArthitecture.Application.Services.Order.Commands.AddOrder;
using CleanArthitecture.Domain.Repositories;
using Common.Helper;
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
            var orderDtoItems = command.ProductId
                .Zip(command.Quantity, (pId, q) => new { ProductId = pId, Quantity = q })
                .Select(pair =>
                {
                    var product = _productRepository.FindByIdAsync(pair.ProductId).Result;
                    product.ThrowIfNull<EmptyProductException>();

                    return new OrderItemDTO
                    (
                        TotalPrice: product.Price * pair.Quantity,
                        ProductId: product.Id,
                        Quantity: pair.Quantity
                    );
                }).ToList();

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
