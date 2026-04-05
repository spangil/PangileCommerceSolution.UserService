using FluentValidation;
using PangileCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PangileCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid Email format");
        RuleFor(x => x.Password)
            .NotNull().WithMessage("Password is required")
            .MaximumLength(50).WithMessage("Password cannot be greater that 50 characters");
        RuleFor(x=>x.PersonName)
            .NotNull().WithMessage("PersonName is required")
            .MaximumLength(50).WithMessage("PersonName cannot be greater that 50 characters");
        RuleFor(x=>x.Gender)
            .IsInEnum();

    }
}
