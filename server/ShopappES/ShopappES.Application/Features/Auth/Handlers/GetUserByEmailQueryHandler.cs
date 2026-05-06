using AutoMapper;
using MediatR;
using ShopappES.Application.Common;
using ShopappES.Application.Features.Auth.DTOs;
using ShopappES.Application.Features.Auth.Interfaces;
using ShopappES.Application.Features.Auth.Queries;

namespace ShopappES.Application.Features.Auth.Handlers;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, ApiResponse<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByEmailQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<UserDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
        {
            return ApiResponse<UserDto>.FailResponse("User not found", 404);
        }

        var userDto = _mapper.Map<UserDto>(user);

        return ApiResponse<UserDto>.SuccessResponse(userDto, "User found");
    }
}