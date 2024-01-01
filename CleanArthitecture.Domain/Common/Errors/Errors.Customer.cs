namespace CleanArthitecture.Domain.Common.Errors;
using ErrorOr;

public static class Errors
{
    public static class Customer
    {
        public static Error DuplicateEmail => Error.Conflict(
            description: "Email in Use");
    }
}