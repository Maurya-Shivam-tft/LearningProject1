using CQRS_Pattern.Data.Query;
using FluentValidation;

namespace CQRS_Pattern.Validators
{
    public class GetEmployeeByIdQueryValidation : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeeByIdQueryValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be null or empty")
                .GreaterThan(0).WithMessage("Id should be greater then 0");


        }

    }
}
