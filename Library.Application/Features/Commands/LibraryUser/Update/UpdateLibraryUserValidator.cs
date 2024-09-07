using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.LibraryUser.Update;

public class UpdateLibraryUserValidator : AbstractValidator<UpdateLibraryUserCommand>
{
    private readonly ILibraryUserRepository _libraryUserRepository;

    public UpdateLibraryUserValidator(ILibraryUserRepository libraryUserRepository)
    {
        _libraryUserRepository = libraryUserRepository;
        RuleFor(u => u.LibraryUserUpdateDto.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(u => u.LibraryUserUpdateDto.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(u => u.LibraryUserUpdateDto.Email)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .EmailAddress().WithMessage("{PropertyName} must be a valid email");

        RuleFor(u => u.LibraryUserUpdateDto.PhoneNumber)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .Matches(@"^\d{10}$").WithMessage("{PropertyName} must be a valid phone number");
    }
}
