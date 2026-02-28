using Checktify.Entity.Identity.ViewModels;
using Checktify.Service.Messages.Identity;
using Checktify.Service.Messages.WebApplication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.FluentValidation.Identity
{
    public class ResetPasswordValidation : AbstractValidator<ResetPasswordVM>
    {
        public ResetPasswordValidation()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessage.NullEmptyMessage("Password"))
                .NotNull().WithMessage(ValidationMessage.NullEmptyMessage("Password"));
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage(ValidationMessage.NullEmptyMessage("ConfirmPassword"))
                .NotNull().WithMessage(ValidationMessage.NullEmptyMessage("ConfirmPassword"))
                .Equal(x => x.Password).WithMessage(IdentityMessages.ComparePassword());
        }
    }
}
