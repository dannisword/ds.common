using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DS.Common.Entities;
using DS.Repository.Db;

namespace DS.Repository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }
        void BeginTransaction();
        int SaveChanges();
        void Commit();
        int Commit(bool usingTransaction);
        void Rollback();
        IRepository<TEntity> Repository<TEntity>();
    }
}