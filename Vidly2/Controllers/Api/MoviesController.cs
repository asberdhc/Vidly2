using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly2.Dtos;
using Vidly2.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace Vidly2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include(m => m.Genre).Select(Mapper.Map<Movie, MovieDTO>));
        }

        //GET /api/movies/{id}
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }
        
        //POST /api/movies
        [HttpPost]
        public IHttpActionResult New(MovieDTO movieDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw ModelState
                        .Select(kvp => new Exception(kvp.Key.Split('.')[1], kvp.Value.Errors[0].Exception))
                        .First();

                var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);

                _context.Movies.Add(movie);
                _context.SaveChanges();

                movieDTO.Id = movie.Id;
                return Created(new Uri(Request.RequestUri.ToString()), movieDTO);
            }
            catch (DbEntityValidationException e)
            {
                return BadRequest(
                    //returning a string with errors foreach entity
                    string.Join(" ",
                        e.EntityValidationErrors
                        .Select(entityErrors =>
                            //creating an string with errors for specific entity
                            string.Join("   ",
                                entityErrors.ValidationErrors
                                .Select(validationErrors => 
                                    "[" + validationErrors.PropertyName + "]: " + validationErrors.ErrorMessage
                                )
                            )
                        )
                    )
                );
            }
            catch (Exception e)
            {
                return BadRequest("[" + e.Message + "]: Unexpected error");
            }
        }

        //PUT /api/movies/{id}
        [HttpPut]
        public IHttpActionResult Update(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDTO, movieInDb);
            _context.SaveChanges();

            return Ok(movieInDb);
        }

        //DELETE /api/movies/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
