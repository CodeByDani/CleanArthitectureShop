using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArthitecture.Application.Events.RegisterCostomer;

public class RegisterCustomerLoggerHandler : INotificationHandler<RegisterCustomerEvent>
{
    readonly ILogger<RegisterCustomerLoggerHandler> _logger;

    public RegisterCustomerLoggerHandler(ILogger<RegisterCustomerLoggerHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(RegisterCustomerEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Customer {notification.FirstName} {notification.LastName} " +
                               $"With {notification.Email} Email Registered Successfully at" +
                               $" {DateTime.Now} Time ");
        return Task.CompletedTask;
    }
}