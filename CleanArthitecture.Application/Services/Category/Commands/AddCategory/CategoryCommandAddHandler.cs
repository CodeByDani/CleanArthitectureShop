using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Category.Commands.AddCategory;

public class AddProductHandler : IRequestHandler<CategoryCommandAdd>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public AddProductHandler(ICategoryRepository categoryRepository, IUnitOfWork uow, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task Handle(CategoryCommandAdd request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Domain.Entities.Category>(request);
        _categoryRepository.Add(category);
        await _uow.SaveAsync();
    }
}