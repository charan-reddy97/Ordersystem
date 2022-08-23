
using Microsoft.EntityFrameworkCore;
using ROS._Core.Entities;
using ROS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ROS.Core
{
    public class UserDbcontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public UserDbcontext(DbContextOptions<UserDbcontext> options)
        //   : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security = False; DataBase =ROS Project; Server =.\\SQLEXPRESS; uid = sa; password = pass@123");
        }
        
    }
}
