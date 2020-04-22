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

namespace Vidly2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers
                .Include(c => c.MembershipType)
                .Select(Mapper.Map<Customer, CustomerDTO>));
        }

        // GET /api/customers/{id}
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }

        // PUT /api/customers/{id}
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDTO, customerInDb);

            _context.SaveChanges();

            return Ok(customerDTO);
        }

        // DELETE /api/customers/{id}
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
