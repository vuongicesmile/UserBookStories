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
        // GET : /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walkDomainModel = await walkRepositories.GetAllAsync();

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

    }
}
