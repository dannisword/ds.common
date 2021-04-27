using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using DS.Common.Cores;
using DS.Common.Entities;
using DS.Repository.Infrastructure;
using DS.Services.Common.Parameters;
using DS.Services.Interface;
using DS.Services.Infrastructure;

namespace DS.Services.Implement
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Role

        public IEnumerable<dynamic> GetRoles(BaseQuery query)
        {
            var predicate = PredicateBuilder.True<Role>();

            if (query.ID > 0)
            {
                predicate = predicate.And(p => p.RoleID == query.ID);
            }
            if (string.IsNullOrEmpty(query.KeyWord) == false)
            {
                predicate = predicate.And(p => p.RoleName.Contains(query.KeyWord));
            }
            var q = this.UnitOfWork.Repository<Role>().Find(predicate);
            if (q.Any())
            {
                return q.ToList();
            }
            return null;
        }

        public int SetRole(Role role)
        {
            var entities = this.find(role);
            // Update
            if (entities.Any())
            {
                this.UnitOfWork.Repository<Role>().Update(role);
                return this.UnitOfWork.SaveChanges();
            }
            else
            {
                // 檢查新增條件
                if (this.unique(role).Any())
                {
                    return 0;
                }
                this.UnitOfWork.Repository<Role>().Add(role);
                return this.UnitOfWork.SaveChanges();
            }
        }

        public int DeleteRole(Role role)
        {
            var entities = this.find(role);
            if (entities.Any())
            {
                role.IsActive = false;
                role.UpdatedAt = DateTime.Now;

                this.UnitOfWork.Repository<Role>().Update(role);
                return this.UnitOfWork.SaveChanges();
            }
            return 0;
        }

        private IEnumerable<Role> find(Role role)
        {
            var q = from a in this.Context.Set<Role>()
                    where a.RoleID == role.RoleID
                    select a;

            return q.AsNoTracking();
        }

        private IEnumerable<Role> unique(Role role)
        {
            var q = from a in this.Context.Set<Role>()
                    where a.RoleID == role.RoleID &&
                          a.RoleCode == role.RoleCode &&
                          a.GroupCode == role.GroupCode
                    select a;
            if (q.Any())
            {
                return q.AsNoTracking();
            }
            return null;
        }

        #endregion

        #region RoleApps

        public IEnumerable<dynamic> GetRoleApps(BaseQuery query)
        {
            var predicate = PredicateBuilder.True<RoleApp>();

            if (query.ID > 0)
            {
                predicate = predicate.And(p => p.RoleID == query.ID);
            }
            // AppID
            var q = this.UnitOfWork.Repository<RoleApp>().Find(predicate);
            if (q.Any())
            {
                return q.ToList();
            }
            return null;
        }

        public int SetRoleApp(RoleApp app)
        {
            var entities = this.find(app);
            if (entities.Any())
            {
                this.UnitOfWork.Repository<RoleApp>().Update(app);
                return this.UnitOfWork.SaveChanges();
            }
            else
            {
                if (this.unique(app).Any())
                {
                    return 0;
                }
                this.UnitOfWork.Repository<RoleApp>().Add(app);
                return this.UnitOfWork.SaveChanges();
            }
        }

        public int DeleteRoleApp(RoleApp app)
        {
            var entities = this.find(app);
            if (entities.Any())
            {
                app.IsActive = false;
                app.UpdatedAt = DateTime.Now;

                this.UnitOfWork.Repository<RoleApp>().Update(app);
                return this.UnitOfWork.SaveChanges();
            }
            return 0;
        }

        private IEnumerable<RoleApp> find(RoleApp app)
        {
            var q = from a in this.Context.Set<RoleApp>()
                    where a.RoleID == app.RoleID &&
                          a.AppID == app.AppID
                    select a;
            return q.AsNoTracking();
        }

        private IEnumerable<RoleApp> unique(RoleApp role)
        {
            var q = from a in this.Context.Set<RoleApp>()
                    where a.RoleID == role.RoleID &&
                          a.AppID == role.AppID
                    select a;
            return q.AsNoTracking();
        }

        #endregion
    }
}