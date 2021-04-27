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
    // UserAccount
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork)
        : base(unitOfWork)
        {
        }

        #region UserAccount

        public IEnumerable<dynamic> GetUserAccounts(UserQuery query)
        {
            var predicate = PredicateBuilder.True<UserAccount>();
            //predicate = predicate.And(p => p.IsActive == true);
            if (query.ID > 0)
            {
                predicate = predicate.And(p => p.UserID == query.ID);
            }
            if (string.IsNullOrEmpty(query.ShortName) == false)
            {
                predicate = predicate.And(p => p.ShortName.Contains(query.ShortName));
            }

            var q = this.UnitOfWork.Repository<UserAccount>().Find(predicate);
            if (q.Any())
            {
                return q.ToList();
            }
            return null;
        }

        public int SetUserAccount(UserAccount user)
        {
            var entities = this.find(user);
            // Update
            if (entities.Any())
            {
                var ds = entities.ToList();
                this.UnitOfWork.Repository<UserAccount>().Update(user);
                return this.UnitOfWork.SaveChanges();
            }
            else
            {
                // 檢查新增條件
                if (this.unique(user).Any())
                {
                    return 0;
                }
                this.UnitOfWork.Repository<UserAccount>().Add(user);
                return this.UnitOfWork.SaveChanges();
            }
        }

        public int DeleteUserAccount(UserAccount user)
        {
            var entities = find(user);
            if (entities.Any())
            {
                this.UnitOfWork.Repository<UserAccount>().Update(user);
                return this.UnitOfWork.SaveChanges();
            }
            return 0;
        }

        private IEnumerable<UserAccount> find(UserAccount user)
        {
            //Expression<Func<UserAccount, bool>> expression = (p) => p.Id == user.Id;

            var q = from a in this.Context.Set<UserAccount>()
                    where a.UserID == user.UserID
                    select a;

            return q.AsNoTracking();
        }

        private IEnumerable<UserAccount> unique(UserAccount user)
        {
            Expression<Func<UserAccount, bool>> express = (p) => p.Email == user.Email;

            return this.UnitOfWork.Repository<UserAccount>().Find(express);
        }
        #endregion

        #region  UserRoles

        public IEnumerable<dynamic> GetUserRoles(BaseQuery query)
        {
            var predicate = PredicateBuilder.True<UserRole>();
            if (query.ID > 0)
            {
                predicate = predicate.And(p => p.UserID == query.ID);
            }
            var q = this.UnitOfWork.Repository<UserRole>().Find(predicate);
            if (q.Any())
            {
                return q.ToList();
            }
            return null;
        }

        public int SetUserRole(UserRole role)
        {
            var entities = this.find(role);
            if (entities.Any())
            {
                this.UnitOfWork.Repository<UserRole>().Update(entities.FirstOrDefault());
                return this.UnitOfWork.SaveChanges();
            }
            else
            {
                this.UnitOfWork.Repository<UserRole>().Add(role);
                return this.UnitOfWork.SaveChanges();
            }
        }

        public int DeleteUserRole(UserRole role)
        {
            var entities = this.find(role);

            if (entities.Any())
            {
                var entity = entities.FirstOrDefault();
                entity.UpdatedAt = role.UpdatedAt;
                entity.UpdatedBy = role.UpdatedBy;
                return this.UnitOfWork.SaveChanges();
            }
            return 0;
        }
        private IEnumerable<UserRole> find(UserRole role)
        {
            Expression<Func<UserRole, bool>> expression = (p) => p.UserID == role.UserID &&
                                                                 p.RoleID == role.RoleID &&
                                                                 p.EndAt == role.EndAt;
            return this.UnitOfWork.Repository<UserRole>().Find(expression);
        }
        #endregion
    }


}