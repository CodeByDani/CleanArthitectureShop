using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Product.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository IProductRepository, IUnitOfWork uow, IMapper mapper)
    {
        _productRepository = IProductRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Domain.Entities.Product>(request);

        _productRepository.Update(product);
        await _uow.SaveAsync();
    }
}