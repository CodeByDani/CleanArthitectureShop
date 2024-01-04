namespace CleanArthitecture.Presentation.DTO;

public record ProductRequest
(
    long CategoryId,
    string NameProduct,
    string Description,
    double Price,
    int Quntity,
    string Color
);