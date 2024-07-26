using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Notes.Application.Interfaces;
using Notes.Core.Models;

namespace Notes.Infrastructure.Services;

public class RedisClient(IDistributedCache redis) : INoteCache
{
    public async Task SetAsync(string stringNote, string userId)
    {
        var cacheOptions = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(20));
        await redis.SetStringAsync(userId, stringNote, cacheOptions);
    }

    public async Task<List<Note>> GetByUserIdAsync(string userId)
    {
        var stringNotes = await redis.GetStringAsync(userId);

        if (string.IsNullOrEmpty(stringNotes))
            return new List<Note>();

        var notes = JsonSerializer.Deserialize<List<Note>>(stringNotes)!;

        return notes;
    }

    public async Task RefreshByUserIdAsync(string userId)
    {
        await redis.RefreshAsync(userId);
    }
}