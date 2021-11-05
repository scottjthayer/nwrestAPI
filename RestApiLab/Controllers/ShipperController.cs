using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApiLab.Models;
using Microsoft.EntityFrameworkCore;

namespace RestApiLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {



        [HttpDelete("delete/{id}")]
        public Shipper DeleteAnimalById(int id)
        {
            Shipper result = new Shipper();
            using (northwindContext context = new northwindContext())
            {
                result = context.Shippers.Include(x => x.Orders).FirstOrDefault(x => x.ShipperId == id);
                context.Shippers.Remove(result);
                context.SaveChanges();
            }
            return result;
        }
    }
}
