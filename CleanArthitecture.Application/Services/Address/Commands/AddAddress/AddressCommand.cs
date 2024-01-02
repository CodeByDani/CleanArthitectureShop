namespace CleanArthitecture.Application.Services.Address.Commands.AddAddress;
using MediatR;

public record AddressCommand
(
    long CustomerId,
    string City,
    string Region,
    string PostalCode,
    string Details
) : IRequest<Domain.Entities.Address>;