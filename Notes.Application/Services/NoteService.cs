using System.Text.Json;
using Notes.Application.Interfaces;
using Notes.Core.Interfaces;
using Notes.Core.Models;

namespace Notes.Application.Services;

public class NoteService(INoteRepository noteRepository
                        , INoteCache noteCache) : INoteService
{
    public async Task<Note> SaveAsync(Note note)
    {
        var noteFromDb = await noteRepository.SaveAsync(note);
        await AddToCache(note.UserId);
        return noteFromDb;
    }

    public async Task<Note> GetByIdAsync(int id)
    {
        var noteFromDb = await noteRepository.GetByIdAsync(id);
        return noteFromDb;
    }

    public async Task<List<Note>> GetByUserIdAsync(int userId)
    {
        var notesFromCache = await noteCache.GetByUserIdAsync(userId.ToString());
        if (notesFromCache.Count != 0)
        {
            await noteCache.RefreshByUserIdAsync(userId.ToString());
            Console.WriteLine("Cache");
            return notesFromCache;
        }

        var notesFromDb = await noteRepository.GetByUserIdAsync(userId);
        Console.WriteLine("Db");
        await AddToCache(userId);
        return notesFromDb;
    }

    public async Task<List<Note>> GetByTimeIntervalAsync(DateTime start, DateTime end)
    {
        var noteFromDb = await noteRepository.GetByTimeIntervalAsync(start, end);
        return noteFromDb;
    }

    public async Task<Note> UpdateAsync(Note note)
    {
        var noteFromDb = await noteRepository.UpdateAsync(note);
        return noteFromDb;
    }

    public async Task DeleteAsync(Note note)
    {
        await noteRepository.DeleteAsync(note);
    }

    private async Task AddToCache(int userId)
    {
        var notesFromDb = await noteRepository.GetByUserIdAsync(userId);
        var notesFromDbJson = JsonSerializer.Serialize(notesFromDb);
        await noteCache.SetAsync(notesFromDbJson, userId.ToString());
    }
}