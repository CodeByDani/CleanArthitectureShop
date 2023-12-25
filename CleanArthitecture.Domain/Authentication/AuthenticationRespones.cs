namespace CleanArthitecture.Domain.Authentication
{
    public record AuthenticationRespones
    (
         long id,
         string? FirstName,
         string? LastName,
         string UserName,
         string Token
    );
}
