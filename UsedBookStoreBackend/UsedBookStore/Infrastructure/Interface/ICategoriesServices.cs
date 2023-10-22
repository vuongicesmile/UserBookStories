using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.Infrastructure.Interface
{
    public interface ICategoriesServices
    {
        Task<IEnumerable<Categories>> GetCategoriesAsync();
    }
}
