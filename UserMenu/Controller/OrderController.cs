using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ROS._Core.Entities;
using ROS._Core.Repository;
using ROS.Core.Entities;
using ROS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMenu.Model;

namespace UserMenu.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderRepository orderRepository;
        private readonly IMenuRepository menuRepository;
        public OrderController(
           IOrderRepository orderRepository,IMenuRepository menuRepository)
        {
            this.orderRepository = orderRepository;
            this.menuRepository = menuRepository;
        }

        public IActionResult Get(int orderid)
        {
            if (orderid > 0)
            {
                var order = orderRepository.FindById(orderid);

                if (order != null)
                    return Ok(order);
                else
                    return NotFound($"Order with the id:{orderid} cannot be found");
            }
            else
                return BadRequest($"InvalidOrder  Id");
        }


        [HttpGet]
        public IActionResult Get()
        {
            var order = orderRepository.GetOrders();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post(List<CartModel> orderItems)
        {
            Order order = new Order();
            order.Status = OrderStatus.InKitchen;
            order.TableNumber = 1; 

            foreach(var cartItem in orderItems)
            {
                order.OrderItems.Add(new OrderItem { Name = cartItem.Dish_Name, OrderQuantity = 1 });
            }

            orderRepository.Add(order);
            return Created($"/api/order/{order.Id}", order);
        }
    }
}