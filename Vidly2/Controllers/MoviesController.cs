using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// this method will be called when we entrer into movies
        /// </summary>
        /// <param name="page"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.CAN_MANAGE_MOVIES) ||
               User.IsInRole(RoleName.TOTAL_CONTROL))
                return View("List");

            return View("ReadOnlyList");
        }

        [HttpGet]
        [Authorize(Roles =
            RoleName.CAN_MANAGE_MOVIES + "," +
            RoleName.TOTAL_CONTROL)]
        public ActionResult New()
        {
            return View("MoviesForm", new MoviesFormViewModel { Genres = _context.Genres });
        }

        [HttpGet]
        [Authorize(Roles =
            RoleName.CAN_MANAGE_MOVIES + "," +
            RoleName.TOTAL_CONTROL)]
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var moviesFormViewModel = new MoviesFormViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                GenreID = movie.GenreID,
                NumberInStock = movie.NumberInStock,
                DateAdded = movie.DateAdded,
                ReleaseDate = movie.ReleaseDate,
                Genres = _context.Genres
            };

            return View("MoviesForm", moviesFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles =
            RoleName.CAN_MANAGE_MOVIES + "," +
            RoleName.TOTAL_CONTROL)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View("MoviesForm", new MoviesFormViewModel {  Genres = _context.Genres });
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.First(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreID = movie.GenreID;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}