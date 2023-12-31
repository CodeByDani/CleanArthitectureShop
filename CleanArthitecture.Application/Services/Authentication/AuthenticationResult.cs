using CleanArthitecture.Domain.Entities;

namespace CleanArthitecture.Application.Services.Authentication;

public record AuthenticationResult(
        Customer Customer,
        string Token);