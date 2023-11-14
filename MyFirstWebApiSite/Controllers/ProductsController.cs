using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsTbl>>> Get(string? name,int? minPrice, int? maxPrice, [FromQuery] int?[] CategoryIds)
        {
            var products= await _productServices.GetProductsAsync(name, minPrice, maxPrice, CategoryIds);
            if (products.Count() > 0)
                return Ok(products);
            return NoContent();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{CategoryId}")]
        public async Task<IEnumerable<ProductsTbl>> Get(int CategoryId)
        {
            return await _productServices.GetProductsByCategoryIdAsync(CategoryId);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
