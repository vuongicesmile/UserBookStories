using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.Repositories
{
    public interface IImageRepository
    {

        Task<Image> Upload(IFormFile file);
        Task<string> DeletePhoto(string publicId);
        Task Upload(Image imageDomainModel);
    }
}
