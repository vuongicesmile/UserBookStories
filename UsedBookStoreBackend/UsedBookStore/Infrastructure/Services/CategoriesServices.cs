using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.Entities;
using UsedBookStore.DataAccess.Interface;
using UsedBookStore.Infrastructure.Interface;

namespace UsedBookStore.Infrastructure.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        //respo : pattern : 
        // bat buoc Unit of Work
        private readonly ICategoriesRepository _categoriesRepository;

        // duoi 1 scope phai co 1 khoang trang
        public CategoriesServices(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<IEnumerable<Categories>> GetCategoriesAsync()
        {
            return await _categoriesRepository.GetAllAsync();
        }
    }
}
