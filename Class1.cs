using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace empp
{
    public class Class1
    {
        public void Adds()
        {
            int a = 5, b = 10;
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine(a + " " + b);
        }
    }
    

/*namespace MyWebApp.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ProductsController : ControllerBase
        {
            private readonly AppDbContext _context;

            public ProductsController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var products = await _context.Products.ToListAsync();
                return Ok(products);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound();
                return Ok(product);
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] Product product)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound();

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
        }
    }*/


}