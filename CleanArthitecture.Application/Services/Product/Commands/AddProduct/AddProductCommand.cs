using MediatR;

namespace CleanArthitecture.Application.Services.Product.Commands.AddProduct;

public record AddProductCommand
(
 string NameProduct,
 string Description,
 double Price,
 int Quntity,
 string Color,
 long CategoryID

) : IRequest;
