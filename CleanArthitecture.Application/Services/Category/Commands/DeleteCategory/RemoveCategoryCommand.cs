using MediatR;

namespace CleanArthitecture.Application.Services.Category.Commands.DeleteCategory;

public record RemoveCategoryCommand(long Id) : IRequest;