using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UsedBookStore.DataAccess.DTOs;
using UsedBookStore.DataAccess.Entities;
using UsedBookStore.DataAccess.Repositories;

namespace UsedBookStore.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepositories walkRepositories;

        public WalksController(IMapper mapper, IWalkRepositories walkRepositories)
        {
            this.mapper = mapper;
            this.walkRepositories = walkRepositories;
        }
        // Create Walk
        //POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRequestWalksDto addRequestWalksDto)
        {
            //map DTO to Domain Model
            var walkDomianModel = mapper.Map<Walk>(addRequestWalksDto);

            await walkRepositories.CreateAsync(walkDomianModel);

            // map domain model to dtos
            return Ok(mapper.Map<WalkDto>(walkDomianModel));

        }

        // Get Walks
        // GET : /api/walks?filterOn=Name&FilterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000
            )
        {
            var walkDomainModel = await walkRepositories.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber,pageSize);

            // map domain model to dto
            return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
        }

        // Get Walk by Id
        // Get : /api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepositories.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // map domain model to dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
        // update Walk By Id
        // PUT : /api/Walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkDto updateWalkDto)
        {
            // map dto to domain model
            var walkDomainModel = mapper.Map<Walk>(updateWalkDto);

            walkDomainModel =  await walkRepositories.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null) { return NotFound(); }

            //map domain model to dto

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
        [HttpDelete]
        // delete : /api/Delete/{id}
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleteWalkDomainModel = await walkRepositories.DeleteAsync(id);
            if (deleteWalkDomainModel == null) 
            { 
            return NotFound();
            }

            // map domain model to dto
            return Ok(mapper.Map<WalkDto>(deleteWalkDomainModel));
        }
    }
}
