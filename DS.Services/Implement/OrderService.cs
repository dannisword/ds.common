using System;
using System.Linq;
using System.Collections.Generic;
using DS.Common.Entities;
using Microsoft.EntityFrameworkCore;

using DS.Services.Interface;
using DS.Repository.Infrastructure;

namespace DS.Services.Implement
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public DbContext Context
        {
            get { return this.UnitOfWork.DbContext; }
        }
        public OrderService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int Add(Order order)
        {
            var o = this.UnitOfWork.Repository<Order>().Insert(order);
            return this.UnitOfWork.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public int Add(Order order, OrderDetail detail)
        {
            int eCode = 0;
            this.UnitOfWork.BeginTransaction();
            try
            {
                //add master 
                var o = this.UnitOfWork.Repository<Order>().Insert(order);
                this.UnitOfWork.SaveChanges();
                var id = order.Id;
                //add detail
                detail.OrderId = o.Id;
                var d = this.UnitOfWork.Repository<OrderDetail>().Insert(detail);
                eCode = this.UnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                this.UnitOfWork.Rollback();
                eCode = -1;
            }
            this.UnitOfWork.Commit();
            return eCode;
        }
        public int Update(Order order)
        {
            this.UnitOfWork.BeginTransaction();
            try
            {
                this.UnitOfWork.Repository<Order>().Update(order);
            }
            catch (Exception e)
            {
                var msg = e.Message;
                this.UnitOfWork.Rollback();
            }
            UnitOfWork.Commit();
            return 1;
        }
        public int UpdateDetail(OrderDetail detail)
        {
            return 1;
        }
        public int CreateOrder(Order order)
        {
            return 0;
        }
        public IEnumerable<Order> GetOrder(int id)
        {
            ICollection<Order> order = new List<Order>();
            //var order = this.UnitOfWork.Repository<Order>().Find(p => p.Id == id);
            var q = from a in this.Context.Set<Order>()
                    from b in this.Context.Set<OrderDetail>()

                    where a.Id == id
                    select a;

            if (q.Any())
            {
                var o = q.ToList();
            }
            return order;
        }

        public int Delete(int OrderId)
        {
            int eCode = 0;
            var q = from a in this.Context.Set<Order>()
                    where a.Id == OrderId
                    select a;

            if (q.Any())
            {
                var o = q.FirstOrDefault();
                this.UnitOfWork.Repository<Order>().Delete(o);
                eCode = this.UnitOfWork.SaveChanges();
            }
            //this.UnitOfWork.Repository<Order>().Delete(OrderId);
            return eCode;
        }
    }
}