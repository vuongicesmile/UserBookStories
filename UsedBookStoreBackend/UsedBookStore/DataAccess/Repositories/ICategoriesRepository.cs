using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.Repositories
{
    public interface ICategoriesRepository
    {
        Task <List<Categories>> GetAllAsync();
    }
}
