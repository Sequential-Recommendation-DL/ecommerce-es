using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Auth.DTOs;

namespace ShopappES.Application.Features.Auth.Commands;
public class LoginCommand : IRequest<ApiResponse<AuthResponseDto>> {
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
