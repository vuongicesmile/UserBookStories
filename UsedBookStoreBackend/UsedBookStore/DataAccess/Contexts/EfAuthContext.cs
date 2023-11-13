

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsedBookStore.DataAccess.Contexts
{
    public class EfAuthContext : IdentityDbContext
    {
        public EfAuthContext(DbContextOptions<EfAuthContext> options) : base(options)
        {

        }
    }
}
