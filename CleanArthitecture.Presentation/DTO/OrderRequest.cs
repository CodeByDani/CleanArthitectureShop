namespace CleanArthitecture.Presentation.DTO;

public record OrderRequest(
    long ProductId,
    int Quantity
);