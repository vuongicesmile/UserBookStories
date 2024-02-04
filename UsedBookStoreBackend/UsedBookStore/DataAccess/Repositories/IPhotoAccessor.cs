using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.Repositories
{
    public interface IPhotoAccessor
    {
        Task<Image> Upload(Image image);

        Task<string> DeletePhoto(string publicId);
    }
}
