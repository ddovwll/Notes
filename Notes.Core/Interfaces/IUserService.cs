using Notes.Core.Models;

namespace Notes.Core.Interfaces;

public interface IUserService
{
    Task<User> SaveAsync(User user);
    Task<User> GetByIdAsync(int id);
    Task<User> GetByNameAsync(string name);
    Task<User> UpdateAsync(User user);
    Task DeleteAsync(User user);
}