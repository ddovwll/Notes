using Microsoft.EntityFrameworkCore;
using Notes.Core.Models;

namespace Notes.Persistence;

public class DbHelper(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }
}