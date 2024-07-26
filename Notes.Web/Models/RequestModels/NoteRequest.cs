namespace Notes.Web.Models.RequestModels;

public record NoteRequest(string Name, string Description, DateTime CreatedAt, int UserId);