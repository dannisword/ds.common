using Microsoft.EntityFrameworkCore;
using DS.Repository.Infrastructure;

namespace DS.Services.Infrastructure
{
    public interface IService<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
        DbContext Context { get; }
        int Add(T t);
    }

    public class ServiceImp<T> : IService<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public DbContext Context { get; private set; }
        public ServiceImp(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.Context = this.UnitOfWork.DbContext;
        }
        public int Add(T t)
        {
            this.Context.Set<T>().Add(t);

            return 0;
        }
    }

}