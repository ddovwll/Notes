using Notes.Core.Models;

namespace Notes.Core.Interfaces;

public interface INoteRepository
{
    Task<Note> SaveAsync(Note note);
    Task<Note> GetByIdAsync(int id);
    Task<List<Note>> GetByUserIdAsync(int userId);
    Task<List<Note>> GetByTimeIntervalAsync(DateTime start, DateTime end);
    Task<Note> UpdateAsync(Note note);
    Task DeleteAsync(Note note);
}