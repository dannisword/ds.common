using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DS.Common.Entities;
using DS.Repository.Infrastructure;

namespace DS.Services.Interface
{
    public interface IOrderService 
    {
        //int Add(Order order, OrderDetail detail);
        //int CreateOrder(Order order);
        //IEnumerable<Order> GetOrder(int Id);

        //int Delete(int OrderId);
        //Get
        int Add(Order order);
        int Add(Order order, OrderDetail detail);
        int Update(Order order);
        int UpdateDetail(OrderDetail detail);
    }


}