using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeClient;
using SomeClient.Controllers;
using System.Web.UI.WebControls;

namespace SomeClient.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            HomeController controller = new HomeController();

            //var result = controller.Index(string.Empty);
            //Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, View, "Error Type");
        }
    }
}
