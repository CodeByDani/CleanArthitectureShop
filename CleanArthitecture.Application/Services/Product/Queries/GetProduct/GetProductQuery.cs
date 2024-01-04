using CleanArthitecture.Application.DTO;
using MediatR;

namespace CleanArthitecture.Application.Services.Product.Queries.GetProduct;

public record GetProductQuery(
    long id
    ) : IRequest<ProductDTO>;