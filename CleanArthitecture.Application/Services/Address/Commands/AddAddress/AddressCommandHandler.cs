using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Domain.Repositories;
using MediatR;

namespace CleanArthitecture.Application.Services.Address.Commands.AddAddress;

public class AddressCommandHandler : IRequestHandler<AddressCommand, Domain.Entities.Address>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _uow;

    public AddressCommandHandler(IAddressRepository addressRepository, IUnitOfWork uow)
    {
        _addressRepository = addressRepository;
        _uow = uow;
    }
    public async Task<Domain.Entities.Address> Handle(AddressCommand request, CancellationToken cancellationToken)
    {
        var address = new Domain.Entities.Address
        {
            City = request.City,
            Details = request.Details,
            PostalCode = request.PostalCode,
            Region = request.Region,
            CustomerId = 1
        };
        _addressRepository.Add(address);
        await _uow.SaveAsync();
        return address;
    }
}