using MediatR;

namespace CleanArthitecture.Application.Services.Category.Commands.UpdateCategory;

public record UpdateCategoryCommand(
    string Name,
    bool IsActive,
    long Id
    ) : IRequest;