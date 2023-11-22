using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductServices productServices;

        public ProductsController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {

            //Console.WriteLine(categoryIds[0]);
            List<Product> products = (List<Product>) await productServices.GetProducts( position,  skip,   desc,   minPrice,   maxPrice,  categoryIds);


            if (products == null)
                return BadRequest();
            return Ok(products);
        }
      
       

   

       
    }
}
