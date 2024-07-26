using Notes.Core.Models;

namespace Notes.Application.Interfaces;

public interface INoteCache
{
    Task SetAsync(string stringNote, string userId);
    Task<List<Note>> GetByUserIdAsync(string userId);
    Task RefreshByUserIdAsync(string userId);
}