using System;
using ComputeDashBoardApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputeDashBoardApp.Tests.Controllers
{
    [TestClass]
    public class Ec2ControllerTest
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var controller = new Ec2InstancesController();
            int pageNum = 1;
            int pageSize = 5;

            var result = controller.Get(pageNum, pageSize);

        }
    }
}
