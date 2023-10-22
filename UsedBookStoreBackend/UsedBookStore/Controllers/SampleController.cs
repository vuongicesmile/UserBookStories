using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsedBookStore.DataAccess.Entities;
using UsedBookStore.Infrastructure.Interface;
using UsedBookStore.Infrastructure.Services;

namespace UsedBookStore.Controllers
{
    [Route("api")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ICategoriesServices _categoriesService;

        public SampleController(ICategoriesServices categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _categoriesService.GetCategoriesAsync();

            return Ok(data);
        }
    }
}
