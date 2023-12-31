using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Application.Common.Interfaces.Authentication;
using CleanArthitecture.Application.Services.Authentication;
using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;
using MediatR;

namespace CleanArthitecture.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtToken;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _uow;

    public RegisterCommandHandler(IJwtTokenGenerator jwtToken, ICustomerRepository customerRepository, IUnitOfWork uow)
    {
        _jwtToken = jwtToken;
        _customerRepository = customerRepository;
        _uow = uow;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        Customer c = await _customerRepository.FindByEmailAsync(command.Email);

        if (c is not null)
        {
            throw new Exception("Hi From Error");
        }

        var customer = new Customer
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
        };
        _customerRepository.Add(customer);
        await _uow.SaveAsync();
        var token = _jwtToken.GenerateToken(customer);
        return new AuthenticationResult(customer, token);
    }
}