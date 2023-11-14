

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsedBookStore.DataAccess.Contexts
{
    public class EfAuthContext : IdentityDbContext
    {
        public EfAuthContext(DbContextOptions<EfAuthContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "8db0a420-2468-49b4-ad4b-cf99dc4984ea";
            var writerRoleId = "aeeaa11e-1e69-44d1-adfd-4014f3e6cade";

            var roles = new List<IdentityRole>
            { 
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                 new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                },
            };

            // we now have to seed this inside the builder object over here
            builder.Entity<IdentityRole>().HasData(roles);
            // so when we run entity framwork core migrations, see this data inject

        }
    }
}
