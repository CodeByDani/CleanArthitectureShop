using CleanArthitecture.Application.Common.Errors;
using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Application.Common.Interfaces.Authentication;
using CleanArthitecture.Application.Events.RegisterCostomer;
using CleanArthitecture.Application.Services.Authentication;
using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;
using MapsterMapper;
using MediatR;

namespace CleanArthitecture.Application.Authentication.Commands.Register;
public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtToken;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    //private readonly IValidator<RegisterCommand> _validator;


    public RegisterCommandHandler(IJwtTokenGenerator jwtToken, ICustomerRepository customerRepository,
        IUnitOfWork uow, IMapper mapper, IMediator mediator)
    {
        _jwtToken = jwtToken;
        _customerRepository = customerRepository;
        _uow = uow;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        Customer c = await _customerRepository.FindByEmailAsync(command.Email);

        if (c is not null)
        {
            throw new DuplicateEmailException();
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

        //! Notification Sender
        var result = _mapper.Map<RegisterCustomerEvent>(customer);
        result.RegistrationDate = DateTime.Now;
        await _mediator.Publish(result, cancellationToken);

        var token = _jwtToken.GenerateToken(customer);
        return new AuthenticationResult(customer, token);
    }
}