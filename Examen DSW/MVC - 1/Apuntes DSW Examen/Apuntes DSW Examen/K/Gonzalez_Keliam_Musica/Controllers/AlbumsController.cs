using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gonzalez_Keliam_Musica.Data;
using Gonzalez_Keliam_Musica.Models;

namespace Gonzalez_Keliam_Musica.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly ChinookContext _context;

        public AlbumsController(ChinookContext context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            //var chinookContext = _context.Albums.Include(a => a.Artist);
            //return View(await chinookContext.ToListAsync());
            var albums = _context.Albums.OrderByDescending(a => a.AlbumId).ToList();
            return View(albums);
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            
            album.Tracks = _context.Tracks.Include(t => t.Album).Where(t => t.AlbumId == id).ToList();
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create

        public IActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name");
            return View();
        }


        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,Title,ArtistId")] Album album)
        {
            var maxAlbumId = _context.Albums.Max(a => (int?)a.AlbumId) ?? 0; // Obtener el valor máximo o 0 si no hay registros
            album.AlbumId = maxAlbumId + 1;

            Artist? artist = await _context.Artists.FirstOrDefaultAsync(a => a.ArtistId == album.ArtistId);
            album.Artist = artist;

            _context.Add(album);
            await _context.SaveChangesAsync();
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
            var artist = await _context.Artists.FindAsync(album.ArtistId);
            album.Artist = artist;

            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,Title,ArtistId")] Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId", album.ArtistId);
            return RedirectToAction(nameof(Index));

            //}
            // ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId", album.ArtistId);
            // return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Albums == null)
            {
                return Problem("Entity set 'ChinookContext.Albums'  is null.");
            }
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
          return (_context.Albums?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        }
    }
}
