using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Auth.DTOs;
using ShopappES.Application.Features.Auth.Interfaces;
using ShopappES.Application.Features.Auth.Commands;

namespace ShopappES.Application.Features.Auth.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse<AuthResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<ApiResponse<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
        {
            return ApiResponse<AuthResponseDto>.FailResponse("Invalid email or password", 401);
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return ApiResponse<AuthResponseDto>.FailResponse("Invalid email or password", 401);
        }

        var token = _tokenService.GenerateToken(user.Id, user.Email, user.FullName);

        var response = new AuthResponseDto
        {
            Token = token,
            Email = user.Email,
            FullName = user.FullName,
            Expiration = _tokenService.GetTokenExpiration()
        };

        return ApiResponse<AuthResponseDto>.SuccessResponse(response, "Login successful");
    }
}