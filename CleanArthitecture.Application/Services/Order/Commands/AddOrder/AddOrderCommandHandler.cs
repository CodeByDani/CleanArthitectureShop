using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Order.Commands.AddOrder;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, long>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    public AddOrderCommandHandler(IUnitOfWork uow,
        IMapper mapper, IOrderRepository orderRepository)
    {
        _uow = uow;
        _mapper = mapper;
        _orderRepository = orderRepository;
    }
    public async Task<long> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Domain.Entities.Order>(request);
        result.OrderDate = DateTime.Now;
        _orderRepository.Add(result);
        await _uow.SaveAsync();
        return _orderRepository.ReturnId(result);
    }
}