using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.DTOs;
using UsedBookStore.DataAccess.Entities;
using UsedBookStore.DataAccess.Repositories;

namespace UsedBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly EfContext dbContext;
        private readonly IPhotoAccessor photoAccessor;

        public PhotoController(IPhotoAccessor photoAccessor)
        {
            this.dbContext = dbContext;
            this.photoAccessor = photoAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ImageUploadRequestDto request)
        {
            if (ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };

                // user repository to upload image
                await photoAccessor.Upload(imageDomainModel);
                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);

        }
    }
}
