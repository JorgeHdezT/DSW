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
    public class AlbumsController : ControllerBase
    {
        private readonly ChinookContext _context;

        public AlbumsController(ChinookContext context)
        {
            _context = context;
        }

        // GET: api/Albums
        [HttpGet]
        [Authorize] //Es necesario estar autorizado para ello.
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
          if (_context.Albums == null)
          {
              return NotFound();
          }

        List<Album> allAlbums = await _context.Albums.ToListAsync();
        //List<Album> diezAlbums = allAlbums.Take(10).ToList();
            //List<Album> diezAlbums = new List<Album>();

            //for(int i = 0; i < 10; i++)
            //{
            //    diezAlbums.Add(allAlbums[i]);
            //}

        var diezAlbums = await _context.Albums.Include(ar => ar.Artist).Include(tr => tr.Tracks).Select(a => new
        {
            Id = a.AlbumId,
            Title = a.Title,
            Artist = new
            {
                //Id = a.Artist.ArtistId,
                Name = a.Artist.Name
            },
            Tracks = a.Tracks.Select(tra => new
            {
                Id = tra.TrackId,
                Name = tra.Name
            }).ToList()

                
        }).OrderByDescending(a => a.Title).Take(10).ToListAsync();

            return Ok(diezAlbums);
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
          if (_context.Albums == null)
          {
              return NotFound();
          }
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, AlbumPostPut albumPostPut)
        {
            if (id != albumPostPut.AlbumPostPutId)
            {
                return BadRequest();
            }

            var existingAlbum = await _context.Albums.FindAsync(id);

            if (existingAlbum == null)
            {
                return NotFound();
            }

            // Actualizar solo las propiedades que se han proporcionado en albumPostPut
            existingAlbum.Title = albumPostPut.Title;
            existingAlbum.ArtistId = albumPostPut.ArtistId;
            // Asegúrate de actualizar otras propiedades según sea necesario

            _context.Entry(existingAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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


        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(AlbumPostPut albumPostPut)
        {
            if (_context.Albums == null)
            {
                return Problem("Entity set 'ChinookContext.Albums' is null.");
            }

            try
            {
                // Mapear las propiedades del DTO a un objeto Album
                var album = new Album
                {
                    Title = albumPostPut.Title,
                    ArtistId = albumPostPut.ArtistId
                    // Asegúrate de asignar otras propiedades según sea necesario
                };

                // Obtener el máximo ID actual y asignar la nueva ID
                int newId = _context.Albums.Max(a => a.AlbumId) + 1;
                album.AlbumId = newId;

                _context.Albums.Add(album);
                await _context.SaveChangesAsync();

                // Cargar el álbum completo con todas sus relaciones
                var completeAlbum = await _context.Albums
                    .Include(a => a.Artist)
                    // Incluye otras relaciones según sea necesario
                    .FirstOrDefaultAsync(a => a.AlbumId == album.AlbumId);

                return CreatedAtAction("GetAlbum", new { id = completeAlbum.AlbumId }, completeAlbum);
            }
            catch (DbUpdateException)
            {
                if (AlbumExists(albumPostPut.ArtistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            if (_context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Tracks)
                .FirstOrDefaultAsync(a => a.AlbumId == id);

            if (album == null)
            {
                return NotFound();
            }

            //// 1. Eliminar canciones del álbum
            //var songsToDelete = _context.Tracks.Where(t => t.AlbumId == id);
            //_context.Tracks.RemoveRange(songsToDelete);

            // 2. Eliminar el álbum
            _context.Albums.Remove(album);

            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool AlbumExists(int id)
        {
            return (_context.Albums?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        }
    }
}
