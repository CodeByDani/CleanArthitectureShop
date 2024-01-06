using MediatR;

namespace CleanArthitecture.Application.Services.Order.Commands.AddOrder;

public record AddOrderCommand
(
    long CustomerId,
    double Amount

) : IRequest<long>;