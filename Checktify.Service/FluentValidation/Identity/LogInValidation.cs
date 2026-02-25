using Checktify.Entity.Identity.ViewModels;
using Checktify.Service.Messages.Identity;
using Checktify.Service.Messages.WebApplication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.FluentValidation.Identity
{
    public class LogInValidation : AbstractValidator<LogInVM>
    {
        public LogInValidation()
        {
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage(ValidationMessage.NullEmptyMessage("Email"))
               .NotNull().WithMessage(ValidationMessage.NullEmptyMessage("Email"))
               .EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessage.NullEmptyMessage("Password"))
                .NotNull().WithMessage(ValidationMessage.NullEmptyMessage("Password"));
        }
    }
}
