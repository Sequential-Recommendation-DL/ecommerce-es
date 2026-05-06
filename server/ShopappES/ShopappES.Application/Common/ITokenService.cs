namespace ShopappES.Application.Common;

public interface ITokenService
{
    string GenerateToken(Guid userId, string email, string fullName);
    DateTime GetTokenExpiration();
}