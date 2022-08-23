using ROS._Core.Entities;
using ROS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS._Core.Repository
{
    public class MenuRepository : IMenuRepository

    {
         UserDbcontext dbContext;

        public MenuRepository(UserDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Menu Add(Menu menu)
        {

            menu.CreatedDate = DateTime.Now;
            dbContext.Menus.Add(menu);
            dbContext.SaveChanges();
            return menu;
        }


        public Menu Update(Menu menu)
        {
            Menu currentMenu = dbContext.Menus.FirstOrDefault(d => d.Id == menu.Id);
            currentMenu.Dish_Name = menu.Dish_Name;
            currentMenu.price = menu.price;
            currentMenu.LastModifiedDate = DateTime.Now;

            dbContext.Update(currentMenu);
            dbContext.SaveChanges();

            return currentMenu;
        }

        public void Delete(int id)
        {
            Menu menu = dbContext.Menus.FirstOrDefault(d => d.Id == id);
            menu.DeletedDate = DateTime.Now;

            dbContext.Update(menu);
            dbContext.SaveChanges();
        }

        public Menu FindById(int id)
        {
            var menu = dbContext.Menus.FirstOrDefault(d => d.Id == id);
            if (menu == null)
                throw new Exception($"Item with the Id : {id} cannot be found");

            return menu;
        }

        public List<Menu> GetMenus()
        {
            return dbContext.Menus.Where(d => d.DeletedDate == null).ToList();
        }



    }
}
