using CleanArthitecture.Domain.Enums;
using MediatR;

namespace CleanArthitecture.Application.Services.Payment.Commands;

public record AddPaymentCommand(
    long CustomerId,
    long OrderId,
    double Amount,
    PaymentStatus Status,
    DateTime DateTime
    ):IRequest;