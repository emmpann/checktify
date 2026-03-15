using Checktify.Entity.DTOs.Authentication;
using FluentValidation;

namespace Checktify.Service.FluentValidation.Identity
{
    public class LogInValidation : AbstractValidator<LogInRequest>
    {
        public LogInValidation()
        {
            //RuleFor(x => x.Email)
            //   .NotEmpty().WithMessage(ValidationMessage.NullEmptyMessage("Email"))
            //   .NotNull().WithMessage(ValidationMessage.NullEmptyMessage("Email"))
            //   .EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());
            //RuleFor(x => x.Password)
            //    .NotEmpty().WithMessage(ValidationMessage.NullEmptyMessage("Password"))
            //    .NotNull().WithMessage(ValidationMessage.NullEmptyMessage("Password"));
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email wajib diisi.")
                .EmailAddress().WithMessage("Format email tidak valid.");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Password wajib diisi.")
                .MinimumLength(8).WithMessage("Password minimal 8 karakter.");
        }
    }
}
