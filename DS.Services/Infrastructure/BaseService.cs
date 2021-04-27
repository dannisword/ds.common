
using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using DS.Common.Models;
using DS.Repository.Infrastructure;
using DS.Services.Common.Parameters;

namespace DS.Services.Infrastructure
{

    public class BaseService 
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public DbContext Context { get; private set; }
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.Context = this.UnitOfWork.DbContext;
        }


    }

    public interface IBaseService<T>
    {
        int Add(T t);

        int Update(T t);
    }

    public class BaseService<T> : IBaseService<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public BaseService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public int Add(T t)
        {
            this.UnitOfWork.DbContext.Set<T>().Add(t);
            return this.UnitOfWork.SaveChanges();
        }

        public int Update(T t)
        {
            this.UnitOfWork.DbContext.Set<T>().Update(t);
            return this.UnitOfWork.SaveChanges();
        }
    }
}