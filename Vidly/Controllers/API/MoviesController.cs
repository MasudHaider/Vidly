using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext _Context;

        public MoviesController()
        {
            _Context = new ApplicationDbContext();
        }

        //GET api/Movies/
        public IEnumerable<MovieDto> GetMovies()
        {
            return _Context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
             var movies = _Context.Movies.SingleOrDefault(m => m.Id == id);

            if (movies == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movies));
        }

        //POST api/Movies/
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movies = Mapper.Map<MovieDto, Movie>(movieDto);

            _Context.Movies.Add(movies);
            _Context.SaveChanges();

            movieDto.Id = movies.Id;

            return Created(new Uri(Request.RequestUri + "/" + movies.Id), movieDto );
        }

        //UPDATE api/Movies/
        [HttpPut]
        public IHttpActionResult UpdateMovies(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var moviesInDb = _Context.Movies.SingleOrDefault(m => m.Id == id);

            if (moviesInDb == null)
                return NotFound();

            Mapper.Map(movieDto, moviesInDb);

            _Context.SaveChanges();

            return Ok();
        }

        //DELETE /api/Movies
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var moviesInDb = _Context.Movies.SingleOrDefault(m => m.Id == id);

            if (moviesInDb == null)
                return NotFound();

            _Context.Movies.Remove(moviesInDb);
            _Context.SaveChanges();

            return Ok();
        }
    }
}
