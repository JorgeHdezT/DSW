using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HernandezJorge_API_Ej2.Data;
using HernandezJorge_API_Ej2.Models;
using Microsoft.AspNetCore.Authorization;

namespace HernandezJorge_API_Ej2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly HernandezJorge_API_Ej2Context _context;

        public GenresController(HernandezJorge_API_Ej2Context context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        [Authorize] //Autorizo los usuarios.
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre()
        {
          if (_context.Genre == null)
          {
              return NotFound();
          }

          var genres = await _context.Genre
                .Select(g => new
                {
                    Id = g.GeneroId,
                    Name = g.Nombre,
                    Games = g.Juegos.Select(g => new { g.Titulo })
                }).ToListAsync();

            return Ok(genres);
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
          if (_context.Genre == null)
          {
              return NotFound();
          }
            var genre = await _context.Genre.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.GeneroId)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
          if (_context.Genre == null)
          {
              return Problem("Entity set 'HernandezJorge_API_Ej2Context.Genre'  is null.");
          }
            _context.Genre.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.GeneroId }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            if (_context.Genre == null)
            {
                return NotFound();
            }
            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreExists(int id)
        {
            return (_context.Genre?.Any(e => e.GeneroId == id)).GetValueOrDefault();
        }
    }
}
