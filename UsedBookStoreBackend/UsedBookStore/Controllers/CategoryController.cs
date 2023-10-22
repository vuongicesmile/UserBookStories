using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EfContext dbContext;
        public CategoryController(EfContext dbContext)
        {
            this.dbContext = dbContext;            
        }
        // GET ALL CATEGORIES
        // GET : https://localhost://portnumber/api/category
        [HttpGet]
        public IActionResult GetAll()
        {
           var categories = dbContext.Categories.ToList();
           return Ok(categories);
        }

        // GET SINGLE CATEGORY  (get category by ID)
        // GET : https://localhost://portnumber/api/category/{id}
        [HttpGet]
        [Route("{id:}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //var category =  dbContext.Categories.Find(id);
            var category = dbContext.Categories.FirstOrDefault(c => c.Id == id);

            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
