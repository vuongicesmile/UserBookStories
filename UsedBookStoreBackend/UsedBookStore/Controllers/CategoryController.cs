using Faker;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.DTOs;
using UsedBookStore.DataAccess.Entities;
using UsedBookStore.DataAccess.Repositories;

namespace UsedBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EfContext dbContext;
        private readonly ICategoriesRepository categoriesRepository;
        public CategoryController(EfContext dbContext, ICategoriesRepository categoriesRepository)
        {
            this.dbContext = dbContext;
            this.categoriesRepository = categoriesRepository;
        }
        // GET ALL CATEGORIES
        // GET : https://localhost://portnumber/api/category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data from Database - Domain models
            //var categoriesDomain =await dbContext.Categories.ToListAsync();
            var categoriesDomain =await categoriesRepository.GetAllAsync();

            //Map Domain Models to DTOs
            var regionsDto = new List<CategoriesDTO>();
            foreach (var category in categoriesDomain)
            {
                regionsDto.Add(new CategoriesDTO()
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }
            return Ok(regionsDto);
        }

        // GET SINGLE CATEGORY  (get category by ID)
        // GET : https://localhost://portnumber/api/category/{id}
        [HttpGet]
        [Route("{id:}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //var category =  dbContext.Categories.Find(id);
            // get region domain modal from database
            var categoryDomain =await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (categoryDomain == null)
            {
                return NotFound();
            }

            // map/convert region domain modal to region DTO 
            var categoriesDto = new CategoriesDTO
            {
                Id = categoryDomain.Id,
                Name = categoryDomain.Name,
            };
            return Ok(categoriesDto);
        }

        //POST To create new categories
        //POST : https://localhost:portnumber/api/categories
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRequestCategories addRequestCategories)
        {
            //Map or convert DTO to domain Model
            var categoriesDomainModel = new Categories
            {
                Name = addRequestCategories.Name,
            };

            // use Domain Modal to create Categories
            await dbContext.Categories.AddAsync(categoriesDomainModel);
            await dbContext.SaveChangesAsync();

            // Map domain modal back to DTO 
            var categoriesDto = new CategoriesDTO
            {
                Id = categoriesDomainModel.Id,
                Name = categoriesDomainModel.Name,
            };

            return CreatedAtAction(nameof(GetById), new { id = categoriesDto.Id }, categoriesDto);
        }

        //Update region
        // PUT : https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoriesDTO updateCategoriesDTO)
        {
            // check if categories exits
            var categoriesDomainModel =await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (categoriesDomainModel == null)
            {
                return NotFound();
            }
            // Map DTO to domain model 
            categoriesDomainModel.Name = updateCategoriesDTO.Name;
            await dbContext.SaveChangesAsync();

            // convert Domain Model to DTO
            var categoryDTO = new CategoriesDTO
            {
                Name = updateCategoriesDTO.Name,
            };

            return Ok(categoriesDomainModel);
        }

        // Delete Categories
        // Delete : https://localhost:portnumber/api/categories/{id}
        [HttpDelete]
        [Route("{id:}")]
        public async  Task<IActionResult> Delete([FromRoute] int id)
        {
            var categoryDomainModel =await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (categoryDomainModel == null)
            {
                return NotFound();
            }

            // delete region
            dbContext.Categories.Remove(categoryDomainModel);
            dbContext.SaveChanges();

            // retun deleted categories back
            // map domain Model to DTO

            var categoriesDto = new CategoriesDTO
            { Name = categoryDomainModel.Name };

            return Ok(categoriesDto);

        }
    }
}
