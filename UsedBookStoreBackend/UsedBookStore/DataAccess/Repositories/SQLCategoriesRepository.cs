using Microsoft.EntityFrameworkCore;
using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.Repositories
{
    public class SQLCategoriesRepository : ICategoriesRepository
    {
        private readonly EfContext dbContext;

        public SQLCategoriesRepository(EfContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Categories>> GetAllAsync()
        {
           return await dbContext.Categories.ToListAsync();

        }
    }
}
