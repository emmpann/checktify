using Checktify.Entity.DTOs.Authentication;
using FluentValidation;

namespace Checktify.Service.FluentValidation.Identity
{
    public class RegisterValidation : AbstractValidator<RegisterRequest>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email wajib diisi.")
            .EmailAddress().WithMessage("Format email tidak valid.")
            .MaximumLength(256).WithMessage("Email maksimal 256 karakter.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username wajib diisi.")
                .MinimumLength(3).WithMessage("Username minimal 3 karakter.")
                .MaximumLength(50).WithMessage("Username maksimal 50 karakter.")
                .Matches("^[a-zA-Z0-9_]+$").WithMessage("Username hanya boleh huruf, angka, dan underscore.");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company wajib diisi.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Format CompanyId tidak valid.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password wajib diisi.")
                .MinimumLength(8).WithMessage("Password minimal 8 karakter.")
                .MaximumLength(100).WithMessage("Password maksimal 100 karakter.")
                .Matches("[A-Z]").WithMessage("Password harus mengandung minimal 1 huruf kapital.")
                .Matches("[a-z]").WithMessage("Password harus mengandung minimal 1 huruf kecil.")
                .Matches("[0-9]").WithMessage("Password harus mengandung minimal 1 angka.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password harus mengandung minimal 1 karakter spesial.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Konfirmasi password wajib diisi.")
                .Equal(x => x.Password).WithMessage("Konfirmasi password tidak cocok.");
        }
    }
}
