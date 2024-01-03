using CleanArthitecture.Application.DTO;
using MediatR;

namespace CleanArthitecture.Application.Services.Category.Queries.GetCategory;

public record GetCategoryQuery(
    long id
    ) : IRequest<CategoryDTO>;