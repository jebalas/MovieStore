using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieLab24.Data;

namespace MovieLab24.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        public IActionResult Search()
        {
            return View();
        }

        public async Task<IActionResult> SearchResultGenre(string genre)
        {

            var movies = await _context.Movies
                .Where(m => m.Genre == genre).ToListAsync();
            ViewBag.GenreSearched = genre;

            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        public async Task<IActionResult> SearchResultTitle(string title)
        {

            var movies = await _context.Movies
                .Where(m => m.Title.Contains(title)).ToListAsync();
            ViewBag.TitleSearched = title;

            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }
        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Year,Actors,Directors,Runtime")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListMovies));
            }
            return View(movies);
        }

        public IActionResult CheckOut(int? id)
        {
            return View();
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }
            return View(movies);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Year,Actors,Directors,Runtime")] Movies movies)
        {
            if (id != movies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesExists(movies.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movies);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movies = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
