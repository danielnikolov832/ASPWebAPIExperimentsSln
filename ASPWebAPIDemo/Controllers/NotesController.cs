using ASPWebAPIDemo.DAL;
using ASPWebAPIDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPWebAPIDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteRepository _noteRepository;

    public NotesController(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    // GET: api/<NotesController>
    [HttpGet]
    public IEnumerable<Note> Get()
    {
        return _noteRepository.GetAll();
    }

    // GET api/<NotesController>/5
    [HttpGet("{id}")]
    public ActionResult<Note> GetById([FromRoute] int id)
    {
        Note? note = _noteRepository.GetById(id);

        if (note is null)
        {
            return NotFound();
        }

        return Created(nameof(GetById), note);
    }

    // POST api/<NotesController>
    [HttpPost]
    public void Post([FromBody] string noteName)
    {
        _noteRepository.Insert(new(noteName));
    }

    // POST api/<NotesController>
    [HttpPost("{id}")]
    public ActionResult<Note> Post([FromRoute] int id,
        [FromBody] string noteName)
    {
        Note? note = _noteRepository.GetById(id);

        if (note is null)
        {
            return NotFound();
        }

        Note newEntity = new(noteName)
        {
            ParentID = id
        };

        _noteRepository.Insert(newEntity);

        return Created(nameof(GetById), newEntity);
    }

    // PUT api/<NotesController>/5
    [HttpPut("{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] string noteName)
    {
        Note note = new(noteName)
        {
            ID = id
        };

        if (note == null)
        {
            return NotFound();
        }

        note.Name = noteName;

        _noteRepository.Update(note);

        return Ok();
    }

    // DELETE api/<NotesController>/5
    [HttpDelete("{id}")]
    public void Delete([FromRoute] int id)
    {
        _noteRepository.Remove(id);
    }
}