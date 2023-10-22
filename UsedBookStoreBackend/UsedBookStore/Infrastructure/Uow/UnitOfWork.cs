using Microsoft.EntityFrameworkCore;
using UsedBookStore.DataAccess.Contexts;

namespace UsedBookStore.Infrastructure.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfContext _context;
        public UnitOfWork(EfContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
           _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
        public DbSet<T> Set<T>() where T : class
        {
            return _context.Set<T>();
        }
    }
}
