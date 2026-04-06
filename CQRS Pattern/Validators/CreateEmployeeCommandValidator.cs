using CQRS_Pattern.Data.Command;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CQRS_Pattern.Validators
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .Matches(@"[a-zA-Z]").WithMessage("Must be string");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("A valid email is required.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .Must(p => p.Trim().Length == 10 && Regex.IsMatch(p.Trim(), @"^[0-9]{10}$"))
                .WithMessage("Phone number must be 10 digits.");

            RuleFor(x => x.Address)
                .NotEmpty().Matches(@"[a-zA-z0-9]").WithMessage("Special Character is not allowed for address")
                .WithMessage("Address is required.");
            //RuleFor(x => x.Name).NotEmpty().WithMessage("nae").Matches(@"[a-z]").WithMessage("string").MaximumLength(30).WithMessage("30");
        }
    }
}
