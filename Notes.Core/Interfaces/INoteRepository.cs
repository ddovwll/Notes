using Notes.Core.Models;

namespace Notes.Core.Interfaces;

public interface INoteRepository
{
    Task<Note> SaveAsync(Note user);
    Task<Note> GetByIdAsync(int id);
    Task<Note> GetByUserIdAsync(int userId);
    Task<Note> GetByTimeInterval(DateTime start, DateTime end);
    Task<Note> UpdateAsync(Note user);
    Task DeleteAsync(Note user);
}