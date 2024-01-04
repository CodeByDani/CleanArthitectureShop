using MediatR;

namespace CleanArthitecture.Application.DTO;

public record ProductDTO(
    string NameProduct,
    string Description,
    double Price,
    int Quntity,
    string Color,
    long CategoryId,
    long Id
    ) : IRequest<List<ProductDTO>>;