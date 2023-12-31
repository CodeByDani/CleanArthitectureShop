using CleanArthitecture.Domain.Entities;

namespace CleanArthitecture.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Customer customer);
    }
}
