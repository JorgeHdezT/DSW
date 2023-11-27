using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIMusica_HernandezJorge.Data;
using APIMusica_HernandezJorge.Models;

namespace APIMusica_HernandezJorge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ChinookContext _context;

        public ArtistsController(ChinookContext context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
          if (_context.Artists == null)
          {
              return NotFound();
          }

            var diezArtistas = await _context.Artists
                .Include(al => al.Albums)
                .Select(a => new
                    {
                        a.ArtistId,
                        a.Name,
                        Album = a.Albums.Select(album => new
                        {
                           album.AlbumId,
                           album.Title
                        }).ToList()
                    }).OrderBy(a=> a.Name).Take(10).ToListAsync();

            return Ok(diezArtistas);
            //return await _context.Artists.ToListAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
          if (_context.Artists == null)
          {
              return NotFound();
          }
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return BadRequest();
            }

            _context.Entry(artist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist([FromBody] Artist artist)
        {
            if (_context.Artists == null)
            {
                return Problem("Entity set 'ChinookContext.Artists' is null.");
            }

            // Obtener el máximo ID actual y asignar la nueva ID
            int newId = _context.Artists.Max(a => a.ArtistId) + 1;
            artist.ArtistId = newId;

            _context.Artists.Add(artist);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArtistExists(artist.ArtistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArtist", new { id = artist.ArtistId }, artist);
        }


        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            if (_context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            // 1. Eliminar canciones del artista
            var songsToDelete = _context.Tracks.Where(t => t.Album.ArtistId == id);
            _context.Tracks.RemoveRange(songsToDelete);

            // 2. Eliminar álbumes del artista
            var albumsToDelete = _context.Albums.Where(a => a.ArtistId == id);
            _context.Albums.RemoveRange(albumsToDelete);

            // 3. Eliminar el artista
            _context.Artists.Remove(artist);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistExists(int id)
        {
            return (_context.Artists?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
}
