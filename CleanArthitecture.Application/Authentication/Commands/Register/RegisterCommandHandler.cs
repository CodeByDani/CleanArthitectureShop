using CleanArthitecture.Application.Common.Errors;
using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Application.Common.Interfaces.Authentication;
using CleanArthitecture.Application.Events.RegisterCostomer;
using CleanArthitecture.Application.Services.Authentication;
using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;
using Common.Helper;
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
        c.ThrowIfNotNull<DuplicateEmailException>();

        var customer = _mapper.Map<Domain.Entities.Customer>(command);
        _customerRepository.Add(customer);
        await _uow.SaveAsync();

        //! Notification Sender
        var result = _mapper.Map<RegisterCustomerEvent>(command);
        await _mediator.Publish(result, cancellationToken);

        var token = _jwtToken.GenerateToken(customer);
        return new AuthenticationResult(customer, token);
    }
}