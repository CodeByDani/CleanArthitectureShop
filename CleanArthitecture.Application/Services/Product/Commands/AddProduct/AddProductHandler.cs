using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Product.Commands.AddProduct;

public class AddProductHandler : IRequestHandler<AddProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public AddProductHandler(IProductRepository productRepository, IUnitOfWork uow, IMapper mapper)
    {
        _productRepository = productRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Domain.Entities.Product>(request);
        _productRepository.Add(product);
        await _uow.SaveAsync();
    }
}