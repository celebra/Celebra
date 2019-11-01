using Microsoft.VisualStudio.TestTools.UnitTesting;
using Celebra.BLTests.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Celebra.BL.Controller;
using Celebra.BL.Model;
using System.Linq;

namespace Celebra.BLTests.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));

            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            Assert.AreEqual(activity.Name, exerciseController.Activities.First().Name);
        }
    }
}