using UsedBookStore.DataAccess.DTOs;
using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.Repositories
{
    public interface ICategoriesRepository
    {
        Task <List<Categories>> GetAllAsync();

        Task<Categories> GetByIdAsync(int id);

        Task<Categories> CreateAsync(Categories categories);

        Task<Categories> UpdateAsync(Categories categories, int id);

        Task<Categories> DeleteAsync(int id);
    }
}
