using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.Repositories
{
    public class SQLWalkRepository : IWalkRepositories
    {
        private readonly EfContext efContext;
        public SQLWalkRepository(EfContext efContext)
        {
            this.efContext = efContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await efContext.Walks.AddAsync(walk);
            await efContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await efContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null) 
            {
                return null;
            }
            efContext.Walks.Remove(existingWalk);
            await efContext.SaveChangesAsync();
            return existingWalk;   
        }

        //public async Task<List<Walk>> GetAllAsync()
        //{
        //    // phuong thuc ToListAsync : get toan bo categories
        //    return await efContext.Walks.Include("Difficulty").ToListAsync();
        //}

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true
            )
        {
            var walks = efContext.Walks.Include("Difficulty").AsQueryable();
            // Filtering
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            // sorting
            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);

                }
                else if(sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);


                }
            }

            return await walks.ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await efContext.Walks.Include(x => x.Difficulty).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id , Walk walk)
        {
            var exitingWalk = await efContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingWalk == null) 
            {
                return null;
            }
            exitingWalk.Name = walk.Name;
            exitingWalk.Description = walk.Description;
            exitingWalk.LengthInKm = walk.LengthInKm;
            exitingWalk.WalkImageUrl = walk.WalkImageUrl;
            exitingWalk.DifficultyId = walk.DifficultyId;

            await efContext.SaveChangesAsync();

            return exitingWalk;
            
        }
    }
}
