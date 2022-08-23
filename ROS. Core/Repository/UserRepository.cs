
using Microsoft.EntityFrameworkCore;
using ROS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        UserDbcontext dbContext;

        public UserRepository(UserDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }


        public User Add(User user)
        {

            user.CreatedDate = DateTime.Now;
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }
        public User Update(User user)
        {
            User currentUser = dbContext.Users.FirstOrDefault(d => d.Id == user.Id);
            if (currentUser != null)
            {
                currentUser.Name = user.Name;
                currentUser.Email = user.Email;
                currentUser.Password = user.Password;
                currentUser.Role = user.Role;
                currentUser.LastModifiedDate = DateTime.Now;


                dbContext.Users.Update(currentUser);
                dbContext.SaveChanges();

            }

            return user;
        }
        public void Delete(int userid)
        {
            User currentUser = dbContext.Users.FirstOrDefault(d => d.Id == userid);
            if (currentUser != null)
            {
                currentUser.DeletedDate = DateTime.Now;
                dbContext.Users.Update(currentUser);
                dbContext.SaveChanges();

            }
        }

        public User FindUserById(int userid)
        {
            return dbContext.Users.FirstOrDefault(d => d.Id == userid);
        }

        public User FindByUserName(string username, string password)
        {
            var user = dbContext.Users.FirstOrDefault(d => d.Email == username
                                                    && d.Password == password
                                                    && d.DeletedDate == null);

            if (user == null)
                throw new Exception($"User does not exist");

            return user;
        }
        public List<User> GetUser()
        {
            return dbContext.Users.Where(d => d.DeletedDate == null).ToList();
        }






    }
}
