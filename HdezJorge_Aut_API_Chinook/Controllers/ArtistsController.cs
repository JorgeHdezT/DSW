using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIMusica_HdezJorge.Data;
using APIMusica_HdezJorge.Models;
using Microsoft.AspNetCore.Authorization;

namespace APIMusica_HdezJorge.Controllers
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
        [Authorize] //Es necesario estar autorizado para ello.

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
        [Authorize] //Debe estar autenticado...
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
        [Authorize] //Debe estar autenticado...
        [Authorize(Roles = "Admin, Manager")] // Solo los admin pueden modificar un album
        public async Task<IActionResult> PutArtist(int id, ArtistPostPut artistPostPut)
        {
            if (id != artistPostPut.ArtistPostPutId)
            {
                return BadRequest();
            }

            var existingArtist = await _context.Artists.FindAsync(id);

            if (existingArtist == null)
            {
                return NotFound();
            }

            // Actualizar solo las propiedades que se han proporcionado en artistPostPut
            existingArtist.Name = artistPostPut.Nombre;
            // Asegúrate de actualizar otras propiedades según sea necesario

            _context.Entry(existingArtist).State = EntityState.Modified;

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
        [Authorize]
        [Authorize(Roles = "Admin, Manager")] // Solo los admin y manager pueden modificar un album

        public async Task<ActionResult<Artist>> PostArtist(ArtistPostPut artistPostPut)
        {
            if (_context.Artists == null)
            {
                return Problem("Entity set 'ChinookContext.Artists' is null.");
            }

            // Mapear las propiedades del DTO a un objeto Artist
            var artist = new Artist
            {
                ArtistId = _context.Artists.Max(a => a.ArtistId) + 1,
                Name = artistPostPut.Nombre
                // Asegúrate de asignar otras propiedades según sea necesario
            };

            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();

            

            return CreatedAtAction("GetArtist", new { id = artist.ArtistId }, artist);
            
        }



        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        [Authorize]
        [Authorize(Roles = "Admin, Manager")] // Solo los admin  o manager pueden modificar un album

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
