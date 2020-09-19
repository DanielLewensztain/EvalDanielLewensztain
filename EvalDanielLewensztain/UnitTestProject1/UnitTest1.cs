using System;
using EvalDanielLewensztain.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            LewensztainsController controller = new LewensztainsController();
            //act
            var lista = controller.GetLewensztains();
            //assert
            Assert.IsNotNull(lista);



        }
    }
}
