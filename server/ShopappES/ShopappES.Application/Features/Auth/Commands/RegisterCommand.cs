using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Auth.DTOs;

namespace ShopappES.Application.Features.Auth.Commands;

public class RegisterCommand : IRequest<ApiResponse<AuthResponseDto>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string RePassword { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
}
