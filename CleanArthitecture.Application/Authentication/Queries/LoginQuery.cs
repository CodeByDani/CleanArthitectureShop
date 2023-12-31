using CleanArthitecture.Application.Services.Authentication;
using MediatR;

namespace CleanArthitecture.Application.Authentication.Queries;

public record LoginQuery
(
    string Email,
    string Password
) : IRequest<AuthenticationResult>;