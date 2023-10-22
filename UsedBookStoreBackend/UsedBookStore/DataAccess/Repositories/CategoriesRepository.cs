using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.Entities;
using UsedBookStore.DataAccess.Interface;

namespace UsedBookStore.DataAccess.Repositories
{
    public class CategoriesRepository : GenericRepository<Categories>, ICategoriesRepository
    {
        private readonly EfContext _efContext;
        public CategoriesRepository(EfContext context) : base(context)
        {
            _efContext = context;
        }
    }
}
