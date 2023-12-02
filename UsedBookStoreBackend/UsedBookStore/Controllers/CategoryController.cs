using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using UsedBookStore.CustomActionFilter;
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
        private readonly IMapper mapper;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(EfContext dbContext,
            ICategoriesRepository categoriesRepository,
            IMapper mapper,
            ILogger<CategoryController> logger
            )
        {
            this.dbContext = dbContext;
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        // GET ALL CATEGORIES
        // GET : https://localhost://portnumber/api/category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            throw new Exception("this is bug");
            logger.LogInformation("get informationddddddd");
            // Get Data from Database - Domain models
            //var categoriesDomain =await dbContext.Categories.ToListAsync();

            //Map Domain Models to DTOs
            //-------------------------------
            //var regionsDto = new List<CategoriesDTO>();
            //foreach (var category in categoriesDomain)
            //{
            //    regionsDto.Add(new CategoriesDTO()
            //    {
            //        Id = category.Id,
            //        Name = category.Name,
            //    });
            //}
            //var categoriesDto = mapper.Map<List<CategoriesDTO>>(categoriesDomain);
            //--------------------------------------
            //Get data from database - domain models

            if(ModelState.IsValid)
            {

                var categoriesDomain = await categoriesRepository.GetAllAsync();
                // Return Dtos
                logger.LogInformation($"finished : {JsonSerializer.Serialize(categoriesDomain)} ");
                return Ok(mapper.Map<List<CategoriesDTO>>(categoriesDomain));
            }
            else { return BadRequest(ModelState); }

        }

        // GET SINGLE CATEGORY  (get category by ID)
        // GET : https://localhost://portnumber/api/category/{id}
        [HttpGet]
        [Route("{id:}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //var category =  dbContext.Categories.Find(id);
            // get region domain modal from database
            //var categoryDomain =await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            var categoryDomain = await categoriesRepository.GetByIdAsync(id);

            if (categoryDomain == null)
            {
                return NotFound();
            }

            // map/convert region domain modal to region DTO 
            //var categoriesDto = new CategoriesDTO
            //{
            //    Id = categoryDomain.Id,
            //    Name = categoryDomain.Name,
            //};
            // return dtos back to client
            return Ok(mapper.Map<CategoriesDTO>(categoryDomain));
        }

        //POST To create new categories
        //POST : https://localhost:portnumber/api/categories
        [HttpPost]
        [ValidateModelAtribute]
        public async Task<IActionResult> Create([FromBody] AddRequestCategories addRequestCategories)
        {
            //Map or convert DTO to domain Model
            //var categoriesDomainModel = new Categories
            //{
            //    Name = addRequestCategories.Name,
            //};
            //if (ModelState.IsValid)
            //{

                var categoriesDomainModel = mapper.Map<Categories>(addRequestCategories);


            // use Domain Modal to create Categories
            //await dbContext.Categories.AddAsync(categoriesDomainModel);
            //await dbContext.SaveChangesAsync();

            //---
            categoriesDomainModel = await categoriesRepository.CreateAsync(categoriesDomainModel);

            // Map domain modal back to DTO 

            var categoriesDto = mapper.Map<CategoriesDTO>(categoriesDomainModel);
            //var categoriesDto = new CategoriesDTO
            //{
            //    Id = categoriesDomainModel.Id,
            //    Name = categoriesDomainModel.Name,
            //};

            // create an exception
            throw new Exception("11");


            return CreatedAtAction(nameof(GetById), new { id = categoriesDto.Id }, categoriesDto);
            //}
            //else { return BadRequest(ModelState); }
        }

        //Update region
        // PUT : https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoriesDTO updateCategoriesDTO)
        {
            // Map DTO to domain model 
            var categoriesDomainModel = mapper.Map<Categories>(updateCategoriesDTO);
            // check if categories exits
            categoriesDomainModel =await categoriesRepository.UpdateAsync(categoriesDomainModel,id);

            if (categoriesDomainModel == null)
            {
                return NotFound();
            }

            // convert Domain Model to DTO
            //var categoryDTO = new CategoriesDTO
            //{
            //    Name = updateCategoriesDTO.Name,
            //};
            var categoryDTO = mapper.Map<CategoriesDTO>(categoriesDomainModel);
            return Ok(categoryDTO);
        }

        // Delete Categories
        // Delete : https://localhost:portnumber/api/categories/{id}
        [HttpDelete]
        [Route("{id:}")]
        public async  Task<IActionResult> Delete([FromRoute] int id)
        {
            var categoryDomainModel =await categoriesRepository.DeleteAsync(id);
            // retun deleted categories back
            // map domain Model to DTO
            return Ok(mapper.Map<CategoriesDTO>(categoryDomainModel));

        }
    }
}
