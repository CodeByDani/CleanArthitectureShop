using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Address.Commands.AddAddress;

public class AddressCommandHandler : IRequestHandler<AddressCommand, Domain.Entities.Address>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public AddressCommandHandler(IAddressRepository addressRepository, IUnitOfWork uow, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _uow = uow;
        _mapper = mapper;
    }
    public async Task<Domain.Entities.Address> Handle(AddressCommand request, CancellationToken cancellationToken)
    {
        var address = _mapper.Map<Domain.Entities.Address>(request);
        _addressRepository.Add(address);
        await _uow.SaveAsync();
        return address;
    }
}