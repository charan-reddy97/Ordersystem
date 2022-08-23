using ROS.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Core.Entities
{
    public enum OrderStatus
    {
        InKitchen,
        Cooking,
        ReadyToServe,
        Completed
    }

    public class Order : Base
    {
        public int TableNumber { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItems { get => orderItems; set => orderItems = value; }

        List<OrderItem> orderItems = new List<OrderItem>();

    }

    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int OrderQuantity { get; set; }
    }
}