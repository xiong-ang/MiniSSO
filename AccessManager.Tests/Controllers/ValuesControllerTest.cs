﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccessManager;
using AccessManager.Controllers;

namespace AccessManager.Tests.Controllers
{
    [TestClass]
    public class AMControllerTest1
    {
        [TestMethod]
        public void Validate()
        {
            // Arrange
            AMController controller = new AMController();

            //// Act
            //IEnumerable<string> result = controller.Get();

            //// Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Count());
            //Assert.AreEqual("value1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void Login()
        {
            // Arrange
            AMController controller = new AMController();

            //// Act
            //controller.Post("value");

            //// Assert
        }
    }
}
