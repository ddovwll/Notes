using Microsoft.EntityFrameworkCore;
using Notes.Core.Models;

namespace Notes.Persistence;

public class DbHelper : DbContext
{
    public DbHelper(DbContextOptions<DbHelper> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }
}