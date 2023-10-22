using Microsoft.EntityFrameworkCore;
using UsedBookStore.DataAccess.Entities;
using UsedBookStore.Infrastructure.Models.Samples;
using UsedBookStore.Infrastructure.Uow;

namespace UsedBookStore.Infrastructure.Services
{
    public interface ISampleService
    {
        Task<IList<SampleModel>> GetAll();
    }
    public class SampleService : ISampleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private DbSet<Sample> SampleSet => _unitOfWork.Set<Sample>();

        public Task<IList<SampleModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
