using Microsoft.EntityFrameworkCore;
using Notes.Core.Interfaces;
using Notes.Core.Models;

namespace Notes.Persistence.Repositories;

public class NoteRepository(DbHelper db) : INoteRepository
{
    public async Task<Note> SaveAsync(Note note)
    {
        await db.Notes.AddAsync(note);
        await db.SaveChangesAsync();
        return note;
    }

    public async Task<Note> GetByIdAsync(int id)
    {
        var noteFromDb = await db.Notes
                             .FindAsync(id)
                         ?? new Note();
        return noteFromDb;
    }

    public async Task<List<Note>> GetByUserIdAsync(int userId)
    {
        var notesFromDb = await db.Notes
            .Where(n => n.UserId == userId)
            .ToListAsync();
        return notesFromDb;
    }

    public async Task<List<Note>> GetByTimeIntervalAsync(DateTime start, DateTime end)
    {
        var notesFromDb = await db.Notes
            .Where(n => n.CreatedAt >= start && n.CreatedAt <= end)
            .ToListAsync();
        return notesFromDb;
    }

    public async Task<Note> UpdateAsync(Note note)
    {
        db.Notes.Update(note);
        await db.SaveChangesAsync();
        return note;
    }

    public async Task DeleteAsync(Note note)
    {
        db.Notes.Remove(note);
        await db.SaveChangesAsync();
    }
}