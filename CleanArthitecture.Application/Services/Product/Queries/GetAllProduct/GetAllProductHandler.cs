using CleanArthitecture.Application.DTO;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Product.Queries.GetAllProduct
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {

            var result = _mapper.Map<List<ProductDTO>>(await _productRepository.GetAll());
            return result;
        }
    }
}
