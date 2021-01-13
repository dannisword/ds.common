using System;
using DS.Common.Entities;

using DS.Repository.Infrastructure;

namespace DS.Repository.Interface 
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        
    }
}