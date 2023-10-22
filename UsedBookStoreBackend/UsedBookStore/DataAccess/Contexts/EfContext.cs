using Microsoft.EntityFrameworkCore;
using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.Contexts
{
    public class EfContext: DbContext
    {
        public EfContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
