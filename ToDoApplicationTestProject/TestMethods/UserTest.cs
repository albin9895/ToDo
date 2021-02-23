using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApplication.Entities.Repository;
using ToDoApplication.Entity;
using ToDoApplication.Service;

namespace ToDoApplicationTestProject.TestMethods
{
    public class UserTest
    {
        private Mock<IRepository<User>> userRepository;
        private List<User> users;
        
        [SetUp]
        public void Setup()
        {
            userRepository = new Mock<IRepository<User>>();
            users = new List<User>();
            users.Add(new User() { FirstName = "User", Id = 1, LastName = "1", Password = "User", Username = "User1" });
            users.Add(new User() { FirstName = "User", Id = 2, LastName = "2", Password = "User", Username = "User2" });
            users.Add(new User() { FirstName = "User", Id = 3, LastName = "3", Password = "User", Username = "User3" });
            users.Add(new User() { FirstName = "User", Id = 4, LastName = "4", Password = "User", Username = "User4" });
        }
        [Test]
        public void TestGetUsers()
        {
            userRepository.Setup(a => a.GetAll()).Returns(users.AsQueryable());
            var UserRegisterService = new UserService(userRepository.Object);
            var UserList = UserRegisterService.Get();

            Assert.IsTrue(UserList.Count == 4);

        }
    }
}
