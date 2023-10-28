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

        public async Task<Categories?> GetByIdAsync(int id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Categories?> CreateAsync(Categories categories)
        {
            await dbContext.Categories.AddAsync(categories);
            await dbContext.SaveChangesAsync();
            return categories;
        }

        public async Task<Categories?> UpdateAsync(Categories categories, int id)
        {
            var exitsCategories = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (exitsCategories == null)
            {
                return null; 
            }

            exitsCategories.Name = categories.Name;

            await dbContext.SaveChangesAsync();
            return exitsCategories;
        }

        public async Task<Categories?> DeleteAsync(int id)
        {
          var exitsCategories = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
          if (exitsCategories == null)
            {
                return null;
            }
            
            dbContext.Categories.Remove(exitsCategories);
            await dbContext.SaveChangesAsync();
            return exitsCategories;
            
        }
    }
}
