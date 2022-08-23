using NUnit.Framework;
using ROS.Core;
using ROS.Core.Entities;
using ROS.Core.Repository;

namespace ROS_Test
{
    [TestFixture]
    public class UserRepositoryTest
    {
        UserDbcontext context1 = new UserDbcontext();

        UserRepository userRepository;
        public UserRepositoryTest()
        {   
             userRepository = new UserRepository(context1);
        }
        [Test]
        public void AddNewUser_ValidData_ReturnsUser()
        {
            //Arrange
            User user = new User();
            user.Email = "satz@gmail.com";
            user.Name = "satz";
            //Act
            var newuser = userRepository.Add(user);
            //Assert
            Assert.IsNotNull(newuser);
            Assert.IsTrue(newuser.Id > 0);
        }
        [Test]
        public void FindById_ValidData_Returnsuser()
        {
            //Arrange
            int id = 1;
            //Act
            var user = userRepository.FindUserById(id);
            //Assert
            Assert.NotNull(user);
            Assert.That(user.Id, Is.EqualTo(id));
        }
        [Test]
        public void GetAllUsers_ValidData_ReturnsListUsers()
        {
            //Arrange 
            //Act
            var Users = userRepository.GetUser();
            //Assert
            Assert.That(Users.Count > 0);
        }
    }
}