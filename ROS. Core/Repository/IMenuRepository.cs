using ROS._Core.Entities;
using System.Collections.Generic;

namespace ROS._Core.Repository
{
    public interface IMenuRepository
    {
        Menu Add(Menu menu);
        void Delete(int id);
        Menu FindById(int id);
        List<Menu> GetMenus();
        Menu Update(Menu menu);
    }
}