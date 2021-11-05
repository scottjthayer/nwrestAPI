using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApiLab.Models;

namespace RestApiLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //api/Customer/getall
        [HttpGet("getall")]
        public List<Customer> GetAllCustomers()
        {
            List<Customer> result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Customers.ToList();
            }
            return result;
        }
        //api/Customer/GetByCity
        [HttpGet("getByCity")]
        public List<Customer> GetByCity(string city)
        {
            List<Customer> result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Customers.Where(c => c.City == city).ToList();
            }
            return result;
        }
        //api/Customer/add?CustomerID={customerId}&CompanyName={name}&ContactName={contact}&City={city}
        [HttpPost("Add")]
        public Customer CreateCustomer(string CustomerId, string CompanyName, string ContactName, string City)
        {
            Customer newCustomer = new Customer();
            newCustomer.CustomerId = CustomerId;
            newCustomer.CompanyName = CompanyName;
            newCustomer.ContactName = ContactName;
            newCustomer.City = City;
            
            using (northwindContext context = new northwindContext())
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }
            return newCustomer;
        } 

    }
}
