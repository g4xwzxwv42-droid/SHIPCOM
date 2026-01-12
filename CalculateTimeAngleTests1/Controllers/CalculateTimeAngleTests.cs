namespace CalculateTimeAngle.Controllers.Tests
{
    [TestClass()]
    public class CalculateTimeAngleTests
    {
        [TestMethod()]
        public void CorrectSingleTimeValue()
        {
            var myobj = new CalculateTimeAngle();

            Assert.AreEqual("90 degrees", myobj.Get("03:00"));
        }

        [TestMethod()]
        public void IncorrectSingleTimeValue()
        {
            var myobj = new CalculateTimeAngle();
            Assert.AreNotEqual("90 degrees", myobj.Get("o3:00"));
        }

        [TestMethod()]
        public void CorrectMultipleTimeValue()
        {
            var myobj = new CalculateTimeAngle();

            Assert.AreEqual("105 degrees", myobj.Get("03","15"));
        }

        [TestMethod()]
        public void CorrectErrorMultipleTimeValue()
        {
            var myobj = new CalculateTimeAngle();

            Assert.AreEqual("Error Calculating the Degrees", myobj.Get("o9", "15"));
        }

        [TestMethod()]
        public void CorrectErrorSingleTimeValue()
        {
            var myobj = new CalculateTimeAngle();

            Assert.AreEqual("Error Calculating the Degrees", myobj.Get("03::00"));
        }
    }
}


