using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Auth.DTOs;

namespace ShopappES.Application.Features.Auth.Queries;

public class GetUserByEmailQuery : IRequest<ApiResponse<UserDto>>
{
    public string Email { get; set; } = string.Empty;
}
