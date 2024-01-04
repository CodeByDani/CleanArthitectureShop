using CleanArthitecture.Application.DTO;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Product.Queries.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDTO>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var prduct = await _productRepository.FindByIdAsync(request.id);
        var result = _mapper.Map<ProductDTO>(prduct);
        return result;
    }
}