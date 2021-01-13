using System;
using DS.Common.Entities;

using DS.Repository.Interface;
using DS.Repository.Infrastructure;

namespace DS.Repository.Implement
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IUnitOfWork unitOf) : base(unitOf)
        {
            Console.WriteLine("OrderRepository");
        }
    }
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IUnitOfWork unitOf) : base(unitOf)
        {
             Console.WriteLine("OrderDetailRepository");
        }
    }
}