using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Application.Services.Order.Commands.AddOrder;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Payment.Commands;

public class AddPaymentHandler:IRequestHandler<AddPaymentCommand>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IOrderRepository _orderRepository;
    public AddPaymentHandler(IUnitOfWork uow,
        IMapper mapper, IPaymentRepository paymentRepository, IOrderRepository orderRepository)
    {
        _uow = uow;
        _mapper = mapper;
        _paymentRepository = paymentRepository;
        _orderRepository = orderRepository;
    }
    public async Task Handle(AddPaymentCommand request, CancellationToken cancellationToken)
    {
        var order =  _orderRepository.FindByIdAsync(request.OrderId).Result;
        var result = _mapper.Map<Domain.Entities.Payment>(request);
        result.Amount = order.Amount;
        _paymentRepository.Add(result);
        await _uow.SaveAsync();
    }
}