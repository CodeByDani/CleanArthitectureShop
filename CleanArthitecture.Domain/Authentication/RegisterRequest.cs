namespace CleanArthitecture.Domain.Authentication
{
    public record RegisterRequest
    (
         string? FirstName,
         string? LastName,
         string PhoneNumber,
         string Email,
         string UserName,
         string Password
    );
}
