using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.DataAccessLayer;
using BookStore.BusinessLogicLayer;
using BookStore.Entity;
using System.Threading.Tasks;
using Moq;

namespace UnitTestForBookStoreManagementSystem
{
    [TestClass]
    public class TestUser
    {
        [TestMethod]
        public async Task TestAddUser()
        {
            var mock = new Mock<IUserDAL>();
            User user = new User();
            user.UserName = "jafajdfh";
            user.EmailId = "jgfeh@bjkd";
            user.IsDeleted = false;
            mock.Setup(p => p.AddUser(user)).ReturnsAsync(true);
            UserBLL userBLL = new UserBLL(mock.Object);
            var actual = await userBLL.AddUser(user);
            Assert.AreEqual(actual, true);
        }
    }
}
