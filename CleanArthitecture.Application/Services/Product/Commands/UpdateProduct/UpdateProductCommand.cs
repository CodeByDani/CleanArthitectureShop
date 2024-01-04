using MediatR;

namespace CleanArthitecture.Application.Services.Product.Commands.UpdateProduct;

public record UpdateProductCommand(
    string NameProduct,
    string Description,
    double Price,
    int Quntity,
    string Color,
    long CategoryID,
    long Id
    ) : IRequest;