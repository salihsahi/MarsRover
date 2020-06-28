using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Tests
{
    [TestClass]
    public class MarsRoverCaseTest
    {
        [TestMethod]
        public void RoverOperationTestSample1()
        {
            string expected = "1 3 N";
            string actual = MarsRoverCaseService.RoverOperation("1 2 N", "LMLMLMLMM");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RoverOperationTestSample2()
        {
            string expected = "5 1 E";
            string actual = MarsRoverCaseService.RoverOperation("3 3 E", "MMRMMRMRRM");

            Assert.AreEqual(expected, actual);
        }
    }
}
