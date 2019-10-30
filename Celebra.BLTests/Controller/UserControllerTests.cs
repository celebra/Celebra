using Microsoft.VisualStudio.TestTools.UnitTesting;
using Celebra.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace Celebra.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "man";
            var birthData = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var controller = new UserController(userName);

            controller.SetNewUserData(gender, birthData, weight, height);
            var controller2 = new UserController(userName);
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthData, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange объявление, данные на вход, данные которые мы ожидаем на выходе
            var userName = Guid.NewGuid().ToString();
            
            // Act действи
            var controller = new UserController(userName);

            // Assert проверяем результат с ожиданиями
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            
        }
    }
}