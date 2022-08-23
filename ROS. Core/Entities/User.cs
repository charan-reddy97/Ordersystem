using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Core.Entities
{
    public enum Role
    {
        CounterReader = 0,
        KitchenAdmin = 1
    }
    public class User : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
