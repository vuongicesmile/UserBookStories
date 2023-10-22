using Microsoft.EntityFrameworkCore;
using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.Interface;

namespace UsedBookStore.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EfContext _context;

        public GenericRepository(EfContext efContext)
        {
            _context = efContext;
        }

        ///
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
