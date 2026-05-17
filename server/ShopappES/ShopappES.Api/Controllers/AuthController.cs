using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Auth.Commands;
using ShopappES.Application.Features.Auth.DTOs;

namespace ShopappES.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost("register")]
        [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var command = new RegisterCommand
            {
                Email = dto.Email,
                Password = dto.Password,
                RePassword = dto.RePassword,
                FullName = dto.FullName
            };
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var command = new LoginCommand
            {
                Email = dto.Email,
                Password = dto.Password
            };
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }
    }

}
