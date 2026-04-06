using CQRS_Pattern.Data.Command;
using FluentValidation;

namespace CQRS_Pattern.Validators
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        { 
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is mandatory for deleting a record")
                .GreaterThan(0).WithMessage("Id should be greater then 0");
        }
    }
}
