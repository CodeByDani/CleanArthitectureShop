using CleanArthitecture.Application.Common.Interfaces.Authentication;
using CleanArthitecture.Application.Services.Authentication;
using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;
using MediatR;

namespace CleanArthitecture.Application.Authentication.Queries;

public class LoginHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtToken;
    private readonly ICustomerRepository _customerRepository;

    public LoginHandler(IJwtTokenGenerator jwtToken, ICustomerRepository customerRepository)
    {
        _jwtToken = jwtToken;
        _customerRepository = customerRepository;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        Customer customer = await _customerRepository.FindByEmailAsync(query.Email);
        if (customer is not Customer)
        {
            throw new Exception("Not Found");
        }

        if (customer.Password != query.Password)
        {
            throw new Exception("Password Incorrect");
        }

        var token = _jwtToken.GenerateToken(customer);
        return new AuthenticationResult(customer, token);

    }
}