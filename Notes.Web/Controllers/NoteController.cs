using Microsoft.AspNetCore.Mvc;
using Notes.Core.Interfaces;
using Notes.Web.Mappers;
using Notes.Web.Models.RequestModels;

namespace Notes.Web.Controllers;

public class NoteController(INoteService noteService) : ControllerBase
{
    [HttpPost("/notes")]
    public async Task<IActionResult> Add([FromBody] NoteRequest noteRequest)
    {
        await noteService.SaveAsync(NoteRequestToNote.Map(noteRequest));

        return Ok();
    }

    [HttpGet("/notes/{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var notes = await noteService.GetByUserIdAsync(id);

        return Ok(notes);
    }
}