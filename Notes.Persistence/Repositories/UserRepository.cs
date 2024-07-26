using Microsoft.EntityFrameworkCore;
using Notes.Core.Interfaces;
using Notes.Core.Models;

namespace Notes.Persistence.Repositories;

public class UserRepository(DbHelper db) : IUserRepository
{
    public async Task<User> SaveAsync(User user)
    {
        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var userFromDb = await db.Users
                             .FindAsync(id)
                         ?? new User();
        return userFromDb;
    }

    public async Task<User> GetByNameAsync(string name)
    {
        var userFromDb = await db.Users
                             .FirstOrDefaultAsync(u => string.Equals(u.Name, name))
                         ?? new User();
        return userFromDb;
    }

    public async Task<User> UpdateAsync(User user)
    {
        db.Users.Update(user);
        await db.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(User user)
    {
        db.Users.Remove(user);
        await db.SaveChangesAsync();
    }
}