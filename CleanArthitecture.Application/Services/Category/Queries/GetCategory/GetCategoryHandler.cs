using CleanArthitecture.Application.DTO;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Category.Queries.GetCategory;

public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, CategoryDTO>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<CategoryDTO> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FindByIdAsync(request.id);
        var result = _mapper.Map<CategoryDTO>(category);
        return result;
    }
}