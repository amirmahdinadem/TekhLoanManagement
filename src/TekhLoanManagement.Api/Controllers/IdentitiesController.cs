using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using TekhLoanManagement.Api.Extensions.ServiceCollection;
using TekhLoanManagement.Application.DTOs;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Entities;
using TekhLoanManagement.Infrastructure.Context;

namespace TekhLoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentitiesController : ControllerBase
    {
       
            private readonly IIdentityService _identityService;

            public IdentitiesController(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterDto input)
            {
                await _identityService.RegisterAsync(input);
                return Ok(new { message = "User registered successfully" });
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginDto input)
            {
                var result = await _identityService.LoginAsync(input);

                return Ok(new
                {
                    accessToken = result.AccessToken,
                    refreshToken = result.RefreshToken
                });
            }

            [HttpPost("refresh-token")]
            public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
            {
                var result = await _identityService.RefreshTokenAsync(refreshToken);

                return Ok(new
                {
                    accessToken = result.AccessToken,
                    refreshToken = result.RefreshToken
                });
            }

            [Authorize]
            [HttpPost("logout")]
            public async Task<IActionResult> Logout()
            {
                var userId = User.GetUserId(); 

                await _identityService.LogoutAsync(userId);

                return Ok(new { message = "Logged out successfully" });
            }

            [Authorize]
            [HttpGet("me")]
            public async Task<IActionResult> Me()
            {
                var user = await _identityService.GetUserAsync(User);

                return Ok(new
                {
                    user.Id,
                    user.UserName,
                    user.MemberId
                });
            }
        }

    
}
