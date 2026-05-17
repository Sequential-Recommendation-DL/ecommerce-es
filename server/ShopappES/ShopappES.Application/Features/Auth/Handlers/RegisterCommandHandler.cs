using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Auth.DTOs;
using ShopappES.Application.Features.Auth.Interfaces;
using ShopappES.Application.Features.Auth.Commands;
using ShopappES.Domain.Entity;

namespace ShopappES.Application.Features.Auth.Handlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ApiResponse<AuthResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public RegisterCommandHandler(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<ApiResponse<AuthResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.ExistsAsync(request.Email))
        {
            return ApiResponse<AuthResponseDto>.FailResponse("Email already exists", 400);
        }

        var user = new User
        {
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            FullName = request.FullName,
            Username = request.Email.Split('@')[0],
            IsActive = true,
            IsEmailVerified = false,
            IsPhoneVerified = false
        };

        await _userRepository.AddAsync(user);

        var token = _tokenService.GenerateToken(user.Id, user.Email, user.FullName);

        var response = new AuthResponseDto
        {
            Token = token,
            Email = user.Email,
            FullName = user.FullName,
            Expiration = _tokenService.GetTokenExpiration()
        };

        return ApiResponse<AuthResponseDto>.SuccessResponse(response, "Registration successful");
    }
}
