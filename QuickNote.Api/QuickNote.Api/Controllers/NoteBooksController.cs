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
    public class NoteBooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NoteBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task< ActionResult<Notebook>> OpenNoteBook(PostNoteBookDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();


            var noteBook = await _context.Notebooks.FirstOrDefaultAsync(x => x.Name == dto.Name);
            if (noteBook == null)
            {
             noteBook = new Notebook() { Name = dto.Name };
            _context.Notebooks.Add(noteBook);
            await _context.SaveChangesAsync();
            }

            return noteBook;            
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNoteBook(int id)
        {
            var noteBook = await _context.Notebooks.FindAsync(id);
            if (noteBook == null) return NotFound();
            _context.Notebooks.Remove(noteBook);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
