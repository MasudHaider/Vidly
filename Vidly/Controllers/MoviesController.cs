using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            var customer = new List<Customer>
            {
                new Customer {Name = "Dave"},
                new Customer {Name = "Nick"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customer
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var genreTypes = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Genres = genreTypes
            };

            return View("MovieForm",viewModel);
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return Content("There is no movie with that name");
            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return Content("There's no movie at this time");
            var viewModel = new MovieFormViewModel
            {
                Movie = movies,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
                
            else
            {
                var moviesInDb = _context.Movies.Single(m => m.Id == movie.Id);

                moviesInDb.Name = movie.Name;
                moviesInDb.ReleaseDate = movie.ReleaseDate;
                moviesInDb.GenreId = movie.GenreId;
                moviesInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}