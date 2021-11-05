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
    public class ProductController : ControllerBase
    {

        //api/Product/getbyname?name={name}
        [HttpGet("getbyname")]
        public Product GetByName(string name)
        {
            Product result = null;
            using (northwindContext context = new northwindContext())
            {
                // result = context.Shippers.Include(x => x.Orders).FirstOrDefault(x => x.ShipperId == id);
                //infinite looping for some reason. 
                result = context.Products.Include(p => p.Category).FirstOrDefault(x => x.ProductName == name);
            }
            return result;
        }
        //api/Product/{id}
        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            Product result = null;
            using (northwindContext context = new northwindContext())
            {
                result = context.Products.Find(id);
            }
            return result;
        }

        //api/Product/Add?
        [HttpPost("add")]
        public Product CreateProduct(int productId, string productName, int supplierId, int categoryId, string quantityPerUnit, decimal unitPrice, short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
        {
            Product newProduct = new Product();
            newProduct.ProductName = productName;
            newProduct.SupplierId = supplierId;
            newProduct.CategoryId = categoryId;
            newProduct.QuantityPerUnit = quantityPerUnit;
            newProduct.UnitPrice = unitPrice;
            newProduct.UnitsInStock = unitsInStock;
            newProduct.UnitsOnOrder = unitsOnOrder;
            newProduct.ReorderLevel = reorderLevel;
            newProduct.Discontinued = discontinued;

            using (northwindContext context = new northwindContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }
            return newProduct;
        }
        
    }
}
