using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.DTO_s.Insurance.Validators
{
    public class CreateInsuranceDtoValidator : AbstractValidator<InsuranceCreateDto>
    {
        public CreateInsuranceDtoValidator() 
        {
            RuleFor(p => p.StartDate)
              .GreaterThanOrEqualTo(p => DateTime.Now).WithMessage("{PropertyName} must be after or equal to current date {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after to start date {ComparisonValue}");
        }
    }
}
