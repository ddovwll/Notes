using Notes.Application.Exceptions;
using Notes.Core.Interfaces;
using Notes.Core.Models;

namespace Notes.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User> SaveAsync(User user)
    {
        var userFromDb = await userRepository.SaveAsync(user);
        return userFromDb;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var userFromDb = await userRepository.GetByIdAsync(id);
        if (userFromDb.Id == 0)
            throw new NotFoundException();
        return userFromDb;
    }

    public async Task<User> GetByNameAsync(string name)
    {
        var userFromDb = await userRepository.GetByNameAsync(name);
        if (userFromDb.Id == 0)
            throw new NotFoundException();
        return userFromDb;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var userFromDb = await userRepository.UpdateAsync(user);
        return userFromDb;
    }

    public async Task DeleteAsync(User user)
    { 
        await userRepository.DeleteAsync(user);
    }
}