using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCarSale.App.Controllers;
using System.Web.Mvc;

namespace MyCarSale.App.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HomeController homecontroller = new HomeController();

            var result = homecontroller.Index();
        }
    }
}
