using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Rossiter.Models;

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
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(AddMovie response) //saves the data from the user into the database
        {
            _context.Movies.Add(response); //add record to database
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
