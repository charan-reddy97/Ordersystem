using ROS.Core.Entities;
using System.Collections.Generic;

namespace ROS.Core.Repository
{
    public interface IUserRepository
    {
        User Add(User user);
        void Delete(int userid);
        User FindByUserName(string username, string password);
        User FindUserById(int userid);
        User Update(User user);
        List<User> GetUser();
    }
}