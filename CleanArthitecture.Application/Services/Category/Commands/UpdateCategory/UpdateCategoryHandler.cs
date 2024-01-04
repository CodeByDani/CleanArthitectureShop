using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Services.Category.Commands.UpdateCategory;

public class UpdateProductHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateProductHandler(ICategoryRepository categoryRepository, IUnitOfWork uow, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Domain.Entities.Category>(request);

        _categoryRepository.Update(category);
        await _uow.SaveAsync();
    }
}