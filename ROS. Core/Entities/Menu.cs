using ROS.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS._Core.Entities
{
    public class Menu : Base
    {
    
        public string Dish_Name { get; set; }
        public int price { get; set; }
        public string Description { get; set; }

        public int Serves { get; set; }
        public string CoverImage { get; set;}

          

    }
}


