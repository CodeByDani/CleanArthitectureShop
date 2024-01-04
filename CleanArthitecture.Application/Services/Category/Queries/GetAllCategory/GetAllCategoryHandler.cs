using CleanArthitecture.Application.DTO;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Category.Queries.GetAllCategory
{
    public class GetAllProductHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {

            var result = _mapper.Map<List<CategoryDTO>>(await _categoryRepository.GetAll());
            return result;
        }
    }
}
