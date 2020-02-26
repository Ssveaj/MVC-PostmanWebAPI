using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postman.Models;

namespace Postman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 01,
                Name = "PC",
                Description = "Med ryzen etc",
                Price = 2500
            },
            new Product
            {
                Id = 02,
                Name = "Laptop",
                Description = "Ink Visual Studio etc",
                Price = 9000
            },
            new Product
            {
                Id = 03,
                Name = "HTC",
                Description = "Garanti livstid etc",
                Price = 7400
            }
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }
        [HttpGet("{id}")] 
        public Product Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            return product;
        }
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            products.Add(product);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = products.Where(p => p.Id == id);
            products = products.Except(product).ToList();
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var existingProduct = products.Where(p => p.Id == id);
            products = products.Except(existingProduct).ToList();

            products.Add(product);
        }
    }
}

/* 
 
    Gå in på Postman.com och ladda ner, därefter kopierar man länken härifrån till
    Postman programmet för att testa olika saker, som till exempel Put, Delete eller Post.
    Om dessa fungerar som det ska då fungerar metoderna som det ska.

    För att se om det fungerar genom att titta på olika koder, till exempel 202, 404 via Postman etc.
     
*/