using ROS.Core.Entities;
using System.Collections.Generic;

namespace ROS.Core.Repository
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        void Delete(int id);
        Order FindById(int id);
        List<Order> GetOrders();
        Order Update(Order order);
    }
}