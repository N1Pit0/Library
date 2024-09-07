using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.LibraryUser.Create;

public class CreateLibraryUserValidator : AbstractValidator<CreateLibraryUserCommand>
{
    private readonly ILibraryUserRepository _libraryUserRepository;

    public CreateLibraryUserValidator(ILibraryUserRepository libraryUserRepository)
    {
        _libraryUserRepository = libraryUserRepository;
        RuleFor(u => u.LibraryUserCreateDto.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(u => u.LibraryUserCreateDto.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(u => u.LibraryUserCreateDto.Email)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .EmailAddress().WithMessage("{PropertyName} must be a valid email");

        RuleFor(u => u.LibraryUserCreateDto.PhoneNumber)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .Matches(@"^\d{10}$").WithMessage("{PropertyName} must be a valid phone number");

        RuleFor(u => u.LibraryUserCreateDto.RegistrationDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Registration Date cannot be in the future");
    }
}
