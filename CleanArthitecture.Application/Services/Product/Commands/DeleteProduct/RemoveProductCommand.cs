using MediatR;

namespace CleanArthitecture.Application.Services.Product.Commands.DeleteProduct;

public record RemoveProductCommand(long Id) : IRequest;