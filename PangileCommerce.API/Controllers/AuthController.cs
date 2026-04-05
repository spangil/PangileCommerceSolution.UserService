using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PangileCommerce.API.Helper;
using PangileCommerce.Core.DTO;
using PangileCommerce.Core.ServiceContracts;
using LoginRequest = PangileCommerce.Core.DTO.LoginRequest;
using RegisterRequest = PangileCommerce.Core.DTO.RegisterRequest;

namespace PangileCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IServiceProvider _serviceProvider;

        public AuthController(IUsersService usersService, IServiceProvider serviceProvider)
        {
            _usersService = usersService;
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest) 
        {
            if(registerRequest is  null) { return BadRequest("Invalid Registration Data"); }

            var validationResult = await ValidatorHelper.ValidateAsync(_serviceProvider, registerRequest, this);
            if (validationResult is not null) return validationResult;

            AuthenticationResponse authenticationResponse =  await _usersService.Register(registerRequest);
            if(authenticationResponse is null || !authenticationResponse.Success) 
            {
                return BadRequest(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest) 
        { 
            if(loginRequest is null) { return BadRequest("Invalid Login Data"); }

            var validationResult = await ValidatorHelper.ValidateAsync(_serviceProvider, loginRequest, this);
            if (validationResult is not null) return validationResult;

            AuthenticationResponse authenticationResponse = await _usersService.Login(loginRequest);
            if(authenticationResponse is null || !authenticationResponse.Success) 
            {
                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }
    }
}
