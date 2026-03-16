using Checktify.Entity.DTOs.Authentication;
using Checktify.Entity.DTOs.General;
using Checktify.Service.Services.Identity.Abstract;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens.Experimental;

namespace Checktify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResult>> Login(LogInRequest request)
        {
            var result = await _authService.LoginAsync(request);

            if (!result.Success)
            {
                return Unauthorized(
                        new ApiResponse<LoginResponse>
                        {
                            Success = false,
                            Message = "Invalid email or password",
                            Errors = result.Errors
                        });
            }

            return Ok(
                new ApiResponse<LoginResponse>
                {
                    Success = true,
                    Message = "Login Succesfully",
                    Data = new LoginResponse
                    {
                        Token = result.Token!,
                        ExpiresIn = result.ExpiresIn,
                        User = result.User,
                    }
                });
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResult>> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            if (result == null || result.Success != true)
                return BadRequest(new { message = "Registration failed" });
            return Ok(result);
        }

        //private ActionResult ToActionResult<T>(Result<T> result)
        //{
        //    if (result.IsSuccess)
        //        return Ok(new
        //        {
        //            data = result.Value,
        //            messages = result.Successes.Select(s => s.Message)
        //        });

        //    var errors = result.Errors.Select(e => new
        //    {
        //        type = e.GetType().Name,
        //        message = e.Message,
        //        field = e is ValidationError ve ? ve.Field : null
        //    });

        //        return result.Errors.FirstOrDefault() switch
        //        {
        //            ValidationError => BadRequest(new { errors }),
        //            NotFoundError => NotFound(new { errors }),
        //            ConflictError => Conflict(new { errors }),
        //            BusinessRuleError => UnprocessableEntity(new { errors }),
        //            InfrastructureError => StatusCode(500, new { errors }),
        //            _ => BadRequest(new { errors })
        //        };
        //}
    }
}
