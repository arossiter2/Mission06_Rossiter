using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Rossiter.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Rossiter.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext someName) //constructor
        {
            _context = someName;
        }

        public IActionResult Index() //loads the index view
        {
            return View();
        }

        public IActionResult Privacy() //loads the privacy view (get to know Joel page)
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie() //loads the add movie page
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult AddMovie(Movie response) //saves the data from the user into the database
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //add record to database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }
            
        }

        public IActionResult Entries()
        {
            var movies = _context.Movies
                .Include(m => m.Category) // Include the Category data
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Entries");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Entries");
        }
    }
}
