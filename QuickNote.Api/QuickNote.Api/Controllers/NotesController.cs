using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickNote.Api.Data;
using QuickNote.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickNote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Note>> GetNotes(int notebookId)
        {
            return await _context.Notes.Where(x => x.NotebookId == notebookId).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return NotFound();
            return note;
        }
        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(PostNoteDto dto )
        {

            if (!ModelState.IsValid)            
                return BadRequest();
            
            var note = new Note()
            {
                Title = dto.Title,
                Content = dto.Content,
                NotebookId = dto.NoteBookId
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new  {id=note.Id},note);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Note>> PutNote( int id, PutNoteDto dto)
        {
            if (id != dto.Id) return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var note = await _context.Notes.FindAsync(id);
            if (note.NotebookId != dto.NoteBookId) return BadRequest();

            note.Title = dto.Title;
            note.Content = dto.Content;
            note.ModifiedTime = DateTimeOffset.Now;

            await _context.SaveChangesAsync();

            return note;

        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return NotFound();
             _context.Remove(note);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}
