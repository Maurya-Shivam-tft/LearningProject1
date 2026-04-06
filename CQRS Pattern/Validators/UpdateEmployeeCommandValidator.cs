using CQRS_Pattern.Data.Command;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CQRS_Pattern.Validators
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(x => x.Id).
                NotEmpty().WithMessage("Id cannot be empty").
                GreaterThan(0).WithMessage("Add valid Id");

            RuleFor(x => x.Name)
                .Matches(@"[a-zA-Z]").WithMessage("Must be string");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("A valid email is required.");

            RuleFor(x => x.Phone)
                .Must(p => p.Trim().Length == 10 && Regex.IsMatch(p.Trim(), @"^[0-9]{10}$"))
                .WithMessage("Phone number must be 10 digits.");

            RuleFor(x => x.Address)
                .Matches(@"[a-zA-z0-9]").WithMessage("Special Character is not allowed for address");

        }
    }
}
