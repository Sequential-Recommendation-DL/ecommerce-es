using Microsoft.EntityFrameworkCore;
using ShopappES.Application.Features.Auth.Interfaces;
using ShopappES.Domain.Entity;
using ShopappES.Infrastructure.Persistence.Postgres.DataContext;

namespace ShopappES.Infrastructure.Persistence.Postgres.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ShopappESDbContext _context;

    public UserRepository(ShopappESDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> AddAsync(User user)
    {
        user.Id = Guid.NewGuid();
        user.CreatedAt = DateTime.UtcNow;
        await _context.Users.AddAsync(user);
        return user;
    }

    public async Task<bool> ExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email && !u.IsDeleted);
    }
}