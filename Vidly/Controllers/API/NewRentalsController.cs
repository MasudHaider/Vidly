using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        public ApplicationDbContext _Context;

        public NewRentalsController()
        {
            _Context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customersInDb = _Context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
            var moviesInDb = _Context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in moviesInDb)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customersInDb,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _Context.Rentals.Add(rental);
            }
            _Context.SaveChanges();
            return Ok();
        }
    }
}
