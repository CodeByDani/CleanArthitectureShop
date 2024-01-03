using MediatR;

namespace CleanArthitecture.Application.Services.Category.Commands.AddCategory;

public record CategoryCommandAdd
(
     string Name,
     bool IsActive
) : IRequest;
