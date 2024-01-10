using MediatR;

namespace CleanArthitecture.Application.Events.RegisterCostomer;

public class RegisterCustomerEvent : INotification
{
    public string FirstName { get; }

    public string LastName { get; }
    public string Email { get; }
    public RegisterCustomerEvent(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}