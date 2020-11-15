using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLab24.Data;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieLab24.Controllers
{
    [Authorize]
    public class CheckedOutMoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckedOutMoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
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
        public async Task<IActionResult> Create(int? id)
        {
            var comovies = new CheckedOutMovies();
            if (ModelState.IsValid)
            {
                comovies.DueDate = DateTime.Today.AddDays(14);
                ViewData["DueDate"] = comovies.DueDate;
                comovies.UserID = HttpContext.User.Identity.Name;
                comovies.MovieID = (int)id;
                //ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == User.Identity.GetUserId());
                _context.CheckedOutMovies.Add(comovies);
                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Result));
            }
            return View(comovies);
        }

        public IActionResult Result()
        {
            return View();
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.CheckedOutMovies
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
            var movies = await _context.CheckedOutMovies.FindAsync(id);
            _context.CheckedOutMovies.Remove(movies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesExists(int id)
        {
            return _context.CheckedOutMovies.Any(e => e.Id == id);
        }
    }
}
