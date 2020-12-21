using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class AlbumController : Controller
    {
        private readonly MvcMusicStoreContext _context;

        public AlbumController(MvcMusicStoreContext context)
        {
            _context = context;
        }

        // GET: Album
        public async Task<IActionResult> Index()
        {
            var mvcMusicStoreContext = _context.Album.Include(a => a.Artist).Include(a => a.Genre);
            return View(await mvcMusicStoreContext.ToListAsync());
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Album/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "Name");
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId");
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            try
            {
                if (string.IsNullOrEmpty(album.Title))
                {
                    ModelState.AddModelError("", "Title is required field");
                    ModelState.AddModelError("Title", "Field Specific - Title is required field");
                }

                if (ModelState.IsValid)
                {
                    _context.Add(album);
                    await _context.SaveChangesAsync();

                    // if you got here, the save worked ... tell the user so.
                    TempData["message"] = $"Album Record added successfully: {album.Title}";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // either way is fine
                ModelState.AddModelError("", ex.GetBaseException().Message);
                TempData["message"] = ex.GetBaseException().Message;
            }

            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "Name", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", album.GenreId);
            return View(album);
        }

        // display the selected album for editing
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "Name", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (id != album.AlbumId) 
            {
                ModelState.AddModelError("", "you're not updating the record you requested");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();

                    TempData["message"] = $"record updated: {album.Title}";
                    return RedirectToAction("Index");

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!AlbumExists(album.AlbumId))
                    {
                        ModelState.AddModelError("", $"albumId is not on file {album.AlbumId}");
                    }
                    else
                    {
                        ModelState.AddModelError("", $"concurrency exception: {ex.GetBaseException().Message}");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"update error: {ex.GetBaseException().Message}");
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "Name", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", album.GenreId);
            return View(album);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var album = await _context.Album.FindAsync(id);
            //_context.Album.Remove(album);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            // changed some code from PPT slide
            try
            {
                var album = _context.Album.Find(id);
                _context.Album.Remove(album);
                await _context.SaveChangesAsync();
                TempData["message"] = $"album title '{album.Title}' deleted from database";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["message"] = "error on delete: " + ex.GetBaseException().Message;
            }
            return RedirectToAction("Delete", new { ID = id });

        }

        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.AlbumId == id);
        }





        // get all records from Album table, using LINQ
        public IActionResult LINQtest()
        {
            try
            {
                var albums = from anAlbum in _context.Album
                             join anArtist in _context.Artist on anAlbum.ArtistId equals anArtist.ArtistId
                             join aGenre in _context.Genre on anAlbum.GenreId equals aGenre.GenreId
                             where (anAlbum.Title.Contains("disc"))
                             select new Album
                             {
                                 AlbumId = anAlbum.AlbumId,
                                 Title = anAlbum.Title,
                                 ArtistId = anAlbum.ArtistId,
                                 GenreId = anAlbum.GenreId,
                                 AlbumArtUrl = anAlbum.AlbumArtUrl,
                                 Artist = anArtist,
                                 Genre = aGenre
                             };

                return View(albums);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"exception getting Albums: {ex.GetBaseException().Message}");
                return View(new List<Album>());
            }
        }

        // get all records from Album table, using Entity Framework
        public IActionResult EFtest()
        {
            try
            {
                //var albums = _context.Album.Include(a => a.Artist).Include(b => b.Genre)
                //    .Where(a => a.Title.Contains("disc") && a.Artist.Name == "Deep Purple");

                //var albums = _context.Album.Include(a => a.Artist).Include(b => b.Genre)
                //    .OrderByDescending(a => a.Artist.Name).ThenBy(a => a.Title);

                var albums = _context.Album.Include(a => a.Artist).Include(b => b.Genre)
                    .Skip(10).Take(10);

                return View("LINQtest", albums);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null) ex = ex.InnerException;
                ModelState.AddModelError("", "exception getting Albums: " + ex.Message);
                return View(new List<Album>());
            }
        }

        public IActionResult LINQtest2()
        {
            var albums = from record in _context.Album.Include(a => a.Artist)
                         select new PriceSurcharged
                         {
                             Title = record.Title,
                             Artist = record.Artist.Name,
                             SurChargePrice = record.Price * (1 + .13),
                             Price = record.Price
                         };
            return View(albums);
        }

        public IActionResult GroupByTest()
        {
            var artistCount = from fred in _context.Album
                              group fred by new
                              {
                                  fred.ArtistId,
                                  fred.Artist.Name
                              } into condensedFred
                              select new LinqTestArtistCount // new View Model
                              {
                                  artist = condensedFred.Key.Name,
                                  count = condensedFred.Count(),
                                  totalPrice = condensedFred.Sum(a => a.Price),
                                  averagePrice = condensedFred.Average(a => a.Price)
                              };
            return View(artistCount.OrderByDescending(a => a.count));
        }

        // action to show all albums with given string in title or artist name
        public ActionResult Search(string query)
        {
            var albums = _context.Album.Include(a => a.Artist)
                .Where(a => a.Title.Contains(query) || a.Artist.Name.Contains(query));
            return View(albums);
        }

    }
}
