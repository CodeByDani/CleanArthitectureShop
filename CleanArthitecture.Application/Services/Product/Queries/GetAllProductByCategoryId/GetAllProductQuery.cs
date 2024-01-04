using CleanArthitecture.Application.DTO;
using MediatR;

namespace CleanArthitecture.Application.Services.Product.Queries.GetAllProductByCategoryId;
public record GetAllProductByCategoryIdQuery(
    long id
) : IRequest<List<ProductDTO>>;