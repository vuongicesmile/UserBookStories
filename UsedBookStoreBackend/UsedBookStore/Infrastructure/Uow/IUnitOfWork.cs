using Microsoft.EntityFrameworkCore;

namespace UsedBookStore.Infrastructure.Uow
{
    public interface IUnitOfWork: IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        int Save();
    }
}
