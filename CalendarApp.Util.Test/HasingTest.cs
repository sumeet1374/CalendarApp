using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarApp.Util.Test
{
    [TestClass]
    public class HasingTest
    {
        [TestMethod]
        public void CanGetHashAndSaltAndCanUseSameSaltForSameString()
        {
            var stringToHash = "Fat$1377";
            var tuple = stringToHash.HashString();
            var hash = tuple.Item1;
            var salt = tuple.Item2;

            var newHashByMethod2 = stringToHash.HashString(salt);
            Assert.AreEqual(hash, newHashByMethod2);

        }
    }
}
