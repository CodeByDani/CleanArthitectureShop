namespace CleanArthitecture.Application.DTO;

public record OrderItemDTO(
 double TotalPrice,
 long ProductId,
 int Quantity
 );