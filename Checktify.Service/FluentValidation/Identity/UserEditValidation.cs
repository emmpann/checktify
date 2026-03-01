using Checktify.Entity.Identity.ViewModels;
using Checktify.Service.Messages.Identity;
using Checktify.Service.Messages.WebApplication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.FluentValidation.Identity
{
    public class UserEditValidation : AbstractValidator<UserEditVM>
    {
        public UserEditValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(ValidationMessage.NullEmptyMessage("Username"))
                .NotNull().WithMessage(ValidationMessage.NullEmptyMessage("Username"));
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidationMessage.NullEmptyMessage("Email"))
                .NotNull().WithMessage(ValidationMessage.NullEmptyMessage("Email"))
                .EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessage.NullEmptyMessage("Password"))
                .NotNull().WithMessage(ValidationMessage.NullEmptyMessage("Password"));
            RuleFor(x => x.ConfirmNewPassword)
                .Equal(x => x.NewPassword).WithMessage(IdentityMessages.ComparePassword());
        }
    }
}
