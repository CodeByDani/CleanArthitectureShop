using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Domain.Repositories;
using MediatR;

namespace CleanArthitecture.Application.Services.Product.Commands.DeleteProduct;

public class RemoveProductHandler : IRequestHandler<RemoveProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _uow;

    public RemoveProductHandler(IProductRepository productRepository, IUnitOfWork uow)
    {
        _productRepository = productRepository;
        _uow = uow;
    }

    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.Id);
        _productRepository.Delete(product);
        await _uow.SaveAsync();
    }
}