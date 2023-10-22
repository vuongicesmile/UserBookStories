using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace UsedBookStore.Controllers
{
    // https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookController : ControllerBase
    {
        // GET : https://localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            string[] categoriesName = new string[] { "A", "B", "C" };
            return Ok(categoriesName);
        }
    }
}
