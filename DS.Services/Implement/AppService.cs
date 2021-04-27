using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using DS.Common.Cores;
using DS.Common.Entities;
using DS.Common.Models;
using DS.Repository.Infrastructure;
using DS.Services.Common.Parameters;
using DS.Services.Interface;
using DS.Services.Infrastructure;

namespace DS.Services.Implement
{
    public class AppService : BaseService, IAppService
    {
        public AppService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<dynamic> GetAppStores(BaseQuery query)
        {
            return null;
        }

        public int SetAppStore(AppStore app)
        {
            var entities = this.find(app);
            // Update
            if (entities.Any())
            {
                this.UnitOfWork.Repository<AppStore>().Update(app);
                return this.UnitOfWork.SaveChanges();
            }
            else
            {
                this.UnitOfWork.Repository<AppStore>().Add(app);
                return this.UnitOfWork.SaveChanges();
            }
        }

        public int DeleteAppStore(AppStore app)
        {
            return 0;
        }

        private IEnumerable<AppStore> find(AppStore app)
        {

            var q = from a in this.UnitOfWork.DbContext.Set<AppStore>()
                    where a.AppID == app.AppID
                    select a;

            return q.AsNoTracking();
        }
    }
}