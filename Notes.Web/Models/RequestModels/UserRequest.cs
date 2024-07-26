namespace Notes.Web.Models.RequestModels;

public record UserRequest(string Name, string Password, string Salt);