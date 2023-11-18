using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.Repositories
{
    public interface IImageRepository
    {

        Task<Image> Upload(Image image);

    }
}
