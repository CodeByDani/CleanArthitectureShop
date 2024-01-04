using CleanArthitecture.Application.DTO;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Product.Queries.GetAllProductByCategoryId
{
    public class GetAllProductByCategoryIdHandler : IRequestHandler<GetAllProductByCategoryIdQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductByCategoryIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductByCategoryId(request.id);
            var result = _mapper.Map<List<ProductDTO>>(products);
            return result;
        }
    }
}
