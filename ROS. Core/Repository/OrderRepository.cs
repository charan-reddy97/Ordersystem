using Microsoft.EntityFrameworkCore;
using ROS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Core.Repository
{
    public class OrderRepository : IOrderRepository
    {
        UserDbcontext dbContext;

        public OrderRepository(UserDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Order Add(Order order)
        {

            order.CreatedDate = DateTime.Now;
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            return order;
        }

        public Order Update(Order order)
        {
            Order currentOrder = dbContext.Orders.FirstOrDefault(d => d.Id == order.Id);
            currentOrder.TableNumber = order.TableNumber;
            currentOrder.Status = order.Status;
            currentOrder.LastModifiedDate = DateTime.Now;

            dbContext.Update(currentOrder);
            dbContext.SaveChanges();

            return currentOrder;
        }

        public void Delete(int id)
        {
            Order order = dbContext.Orders.FirstOrDefault(d => d.Id == id);
            order.DeletedDate = DateTime.Now;
            dbContext.Update(order);
            dbContext.SaveChanges();
        }

        public Order FindById(int id)
        {
            var order = dbContext.Orders.FirstOrDefault(d => d.Id == id);
            if (order == null)
                throw new Exception($"Item with the Id : {id} cannot be found");

            return order;
        }

        public List<Order> GetOrders()
        {
            return dbContext.Orders.Include(d => d.OrderItems).Where(d => d.DeletedDate == null).ToList();
        }



    }
}