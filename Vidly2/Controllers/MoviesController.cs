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

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            var viewModel = new RandomMovieViewModel
            {
                Movies = movies
            };
            return View(viewModel);
            //return Content(movie.Name);
            //return HttpNotFound(movie.Name);
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});

            //return new EmptyResult();
        }

        /// <summary>
        /// method used to show how parameters works
        /// 
        /// note: the default parameter is located into RouteConfig.cs contained in App_Start folder
        /// </summary>
        /// <returns></returns>
        public ActionResult DisplayDefaultParameter(int id)
        {
            return Content("id =" + id);
        }

        /// <summary>
        /// this method will be called when we entrer into movies
        /// </summary>
        /// <param name="page"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public ActionResult Index(int? page, string sortBy)
        {
            if (!page.HasValue)
                page = 1;
            if (String.IsNullOrEmpty(sortBy))
                sortBy = "name";

            return Content(String.Format("PageIndex={0}&sortBy={1}", page, sortBy));
        }

        /// <summary>
        /// the mapRout for this method is hard coding in RouteConfig
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month + "ReleaseBate");
        }

        /// <summary>
        /// with the route parameters enabled in RouteConfig we can use the following atribute
        /// to set the mapRoute the whole URL
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [Route("movies/released2/{year:int}/{month:regex(\\d{2})}")]
        public ActionResult ByRelease(int year, int month)
        {
            return Content(year + "/" + month + "Released");
        }

        [Route("movies/display/{Id:decimal}")]
        public ActionResult Display(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == Id);

            return View(movie);
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == Id);

            var moviesFormViewModel = new MoviesFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres
            };

            if (movie == null)
                new HttpNotFoundResult();

            return View("MoviesForm", moviesFormViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
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

            return RedirectToAction("Random", "Movies");
        }
    }
}