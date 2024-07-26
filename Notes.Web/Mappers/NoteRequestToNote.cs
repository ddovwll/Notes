using Notes.Core.Models;
using Notes.Web.Models.RequestModels;

namespace Notes.Web.Mappers;

public static class NoteRequestToNote
{
    public static Note Map(NoteRequest noteRequest)
    {
        return new Note()
        {
            Name = noteRequest.Name,
            Description = noteRequest.Description,
            CreatedAt = noteRequest.CreatedAt,
            UserId = noteRequest.UserId
        };
    }
}