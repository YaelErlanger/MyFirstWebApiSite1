using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using NLog.Web;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductServices productServices, IMapper mapper, ILogger<ProductsController> logger)
        {
            _productServices = productServices;
            _mapper = mapper;
            _logger = logger;
        }
        // GET: api/<ProductsController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductAndCategoryDTO>>> Get(string? name,int? minPrice, int? maxPrice, [FromQuery] int?[] CategoryIds)
        {
            _logger.LogInformation("this is the productDTO ");
            IEnumerable<ProductsTbl> products= await _productServices.GetProductsAsync(name, minPrice, maxPrice, CategoryIds);
            IEnumerable<ProductAndCategoryDTO> productsDTO = _mapper.Map<IEnumerable<ProductsTbl>, IEnumerable<ProductAndCategoryDTO>>(products);
            if (productsDTO.Count() > 0)
                 return Ok(productsDTO);
                  
            return NoContent();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{CategoryId}")]
        public async Task<IEnumerable<ProductsTbl>> Get(int CategoryId)
        {
            return await _productServices.GetProductsByCategoryIdAsync(CategoryId);
        }

       
       
    }
}
