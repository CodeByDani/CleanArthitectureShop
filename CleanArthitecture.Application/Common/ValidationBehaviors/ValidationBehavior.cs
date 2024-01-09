using CleanArthitecture.Application.Common.Errors;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace CleanArthitecture.Application.Common.ValidationBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors.ConvertAll(validationFailure
                => Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));

            var validationMessage = string.Empty;
            foreach (var error in errors.Select((value, index) => (value, index)))
            {
                validationMessage += string.Format($"  {error.index + 1}: {error.value.Description}");
            }
            throw new ValidationErrors(validationMessage);

        }

    }

}