using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices categoryService;

        public CategoryController(ICategoryServices categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {

            return await categoryService.GetCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<Category?> Get(int id)
        {
            return await categoryService.GetCategoryById(id);
        }

     
    }
}
