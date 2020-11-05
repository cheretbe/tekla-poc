using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TeklaObjectsOperations;
using TSM = Tekla.Structures.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<ITSModelWrapper>();
            TeklaObjectsOperations.MockTest dummy = new MockTest();
            mock.Setup(e => e.GetConnectionStatus()).Returns(true);

            bool callResult = dummy.DoTest(mock.Object);

            Assert.IsTrue(callResult);
        }
    }
}
