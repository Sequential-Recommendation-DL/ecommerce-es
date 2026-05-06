using ShopappES.Domain.Entity;

namespace ShopappES.Application.Features.Auth.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid id);
    Task<User> AddAsync(User user);
    Task<bool> ExistsAsync(string email);
}