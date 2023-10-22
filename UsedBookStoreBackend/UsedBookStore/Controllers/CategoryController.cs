using Faker;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.DTOs;
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
            // Get Data from Database - Domain models
            var categoriesDomain = dbContext.Categories.ToList();

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
        public IActionResult GetById([FromRoute] int id)
        {
            //var category =  dbContext.Categories.Find(id);
            // get region domain modal from database
            var categoryDomain = dbContext.Categories.FirstOrDefault(c => c.Id == id);

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
        public IActionResult Create([FromBody] AddRequestCategories addRequestCategories)
        {
            //Map or convert DTO to domain Model
            var categoriesDomainModel = new Categories
            {
                Name = addRequestCategories.Name,
            };

            // use Domain Modal to create Categories
            dbContext.Categories.Add(categoriesDomainModel);
            dbContext.SaveChanges();

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

        public IActionResult Update([FromRoute] int id, [FromBody] UpdateCategoriesDTO updateCategoriesDTO)
        {
            // check if categories exits
            var categoriesDomainModel = dbContext.Categories.FirstOrDefault(c => c.Id == id);

            if (categoriesDomainModel == null)
            {
                return NotFound();
            }
            // Map DTO to domain model 
            categoriesDomainModel.Name = updateCategoriesDTO.Name;
            dbContext.SaveChanges();

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
        public IActionResult Delete([FromRoute] int id)
        {
            var categoryDomainModel = dbContext.Categories.FirstOrDefault(x => x.Id == id);

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
