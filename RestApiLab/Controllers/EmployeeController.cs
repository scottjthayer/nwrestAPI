using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestApiLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //api/Employee/getall
        [HttpGet("getAll")]
        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Employees.ToList();
            }
            return result;
        }
        //api/Employee/{id}
        [HttpGet("{id}")]
        public Employee GetEmployeeById(int id)
        {
            Employee result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Employees.Find(id);
            }
            return result;
        }

        [HttpPost("add")]
        public Employee AddEmployee(int employeeId, string lastName, string firstName, string title, string titleOfCourtesy, string address, string city, string postalCode, int reportsTo)
        {
            Employee newEmployee = new Employee();
            newEmployee.LastName = lastName;
            newEmployee.FirstName = firstName;
            newEmployee.FirstName = firstName;
            newEmployee.Title = title;
            newEmployee.TitleOfCourtesy = titleOfCourtesy;
            newEmployee.Address = address;
            newEmployee.City = city;
            newEmployee.PostalCode = postalCode;
            newEmployee.ReportsTo = reportsTo;

            using (northwindContext context = new northwindContext())
            {
                context.Employees.Add(newEmployee);
                context.SaveChanges();
            }
            return newEmployee;


        }
    }
}
