﻿namespace Notes.Core.Models;

public class Note
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}