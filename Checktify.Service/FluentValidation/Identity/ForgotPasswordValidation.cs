using Checktify.Entity.Identity.ViewModels;
using Checktify.Service.Messages.Identity;
using Checktify.Service.Messages.WebApplication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.FluentValidation.Identity
{
    public class ForgotPasswordValidation : AbstractValidator<ForgotPasswordVM>
    {
        public ForgotPasswordValidation()
        {
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage(ValidationMessage.NullEmptyMessage("Email"))
               .NotNull().WithMessage(ValidationMessage.NullEmptyMessage("Email"))
               .EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());
        }
    }
}
