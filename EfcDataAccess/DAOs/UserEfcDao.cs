using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly AppDbContext context;

    public UserEfcDao(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.Username.ToLower().Equals(username.ToLower())
        );
        return existing;
    }

    public Task<IEnumerable<User>?> GetUsersByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>?> GetAllUsers()
    {
        IEnumerable<User> users = context.Users;
        return users;
    }
}