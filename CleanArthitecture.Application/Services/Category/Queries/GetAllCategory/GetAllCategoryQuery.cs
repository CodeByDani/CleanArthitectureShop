using CleanArthitecture.Application.DTO;
using MediatR;

namespace CleanArthitecture.Application.Services.Category.Queries.GetAllCategory;
public record GetAllCategoryQuery(
) : IRequest<List<CategoryDTO>>;