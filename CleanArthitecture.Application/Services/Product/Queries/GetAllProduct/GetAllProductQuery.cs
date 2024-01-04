using CleanArthitecture.Application.DTO;
using MediatR;

namespace CleanArthitecture.Application.Services.Product.Queries.GetAllProduct;
public record GetAllProductQuery(
) : IRequest<List<ProductDTO>>;