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

        public DbSet<Difficulty> Difficulty { get; set; }

        // Create the structure by writing override on model creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data for difficulties 
            //easy , medium , hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("e93f05be-4b4b-48be-accf-6a517cdbe047"),
                    Name= "Easy",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("fd916900-429f-4102-915a-0464670c3a65"),
                    Name= "Medium",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("7eecec1a-1bc4-4a9c-b155-9c9380289918"),
                    Name= "Hard",
                },
            };

            // Seed difficulties to the datatbase
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

        }


    }
}
