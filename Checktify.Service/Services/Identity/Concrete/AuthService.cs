using AutoMapper;
using Checktify.Entity.DTOs.Authentication;
using Checktify.Entity.Identity.Entities;
using Checktify.Service.Services.Identity.Abstract;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Checktify.Service.Services.Identity.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IValidator<LogInRequest> _loginValidator;
        private readonly IValidator<RegisterRequest> _registerValidator;
        private readonly IMapper _mapper;

        public AuthService(IConfiguration configuration, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IValidator<LogInRequest> loginValidator, IValidator<RegisterRequest> registerValidator)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
        }

        public async Task<RegisterResult> RegisterAsync(RegisterRequest request)
        {
            var response = new RegisterResult { Success = false, Errors = new List<string>() };

            // Validate request using FluentValidation if a validator is registered
            if (_registerValidator != null)
            {
                var validation = await _registerValidator.ValidateAsync(request);
                if (!validation.IsValid)
                {
                    response.Errors = validation.Errors.Select(e => e.ErrorMessage).ToList();
                    return response;
                }
            }

            var existing = await _userManager.FindByEmailAsync(request.Email);
            if (existing != null)
            {
                response.Errors.Add("Email already registered");
                return response;
            }

            var user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                NormalizedUserName = request.Email.ToUpper(),
                EmailConfirmed = true,
                CreatedDate = DateTime.Now.ToString("d")
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                response.Errors = result.Errors.Select(e => e.Description).ToList();
                return response;
            }

            // Optionally assign default role here
            // await _userManager.AddToRoleAsync(user, "User");

            response.Success = true;
            return response;
        }

        public async Task<LoginResult> LoginAsync(LogInRequest request)
        {
            var response = new LoginResult { Success = false, Errors = new List<string>() };

            // Validate login request if validator is available
            if (_loginValidator != null)
            {
                ValidationResult validation = await _loginValidator.ValidateAsync(request);
                if (!validation.IsValid)
                {
                    response.Errors = validation.Errors.Select(e => e.ErrorMessage).ToList();
                    return response;
                }
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(request.Email);
                if (user == null)
                {
                    response.Errors.Add("Invalid Email or Username");
                    return response;
                }
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!passwordValid)
            {
                response.Errors.Add("Invalid password");
                return response;
            }
            
            var token = CreateToken(user);
            var userDto = _mapper.Map<UserDto>(user);
            
            response.Success = true;
            response.Token = token;
            response.User = userDto;

            return response;
        }

        private string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id!)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!)
                );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
