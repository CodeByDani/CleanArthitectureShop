namespace CleanArthitecture.Domain.Authentication
{
    public record LoginRequest
    (
         string UserName,
         string Password
    );
}
