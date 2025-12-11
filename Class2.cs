using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // Sample data
        private static readonly List<string> Products = new List<string>
        {
            "Laptop",
            "Phone",
            "Tablet"
        };

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 0 || id >= Products.Count)
                return NotFound();

            return Ok(Products[id]);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Create([FromBody] string product)
        {
            Products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = Products.Count - 1 }, product);
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= Products.Count)
                return NotFound();

            var product = Products[id];
            Products.RemoveAt(id);
            return Ok(product);
        }
    }
}
