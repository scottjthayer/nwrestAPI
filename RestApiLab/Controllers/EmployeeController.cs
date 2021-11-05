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


        
    }
}
