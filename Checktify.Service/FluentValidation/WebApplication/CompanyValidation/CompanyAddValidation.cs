using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.FluentValidation.WebApplication.CompanyValidation
{
    public class CompanyAddValidation : AbstractValidator<CompanyAddVM>
    {
        public CompanyAddValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Company name is required.");
            RuleFor(x => x.Code).NotEmpty().NotNull().WithMessage("Company code is required.");
        }
    }
}
