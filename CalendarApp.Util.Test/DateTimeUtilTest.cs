using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Util.Test
{
    [TestClass]
    public class DateTimeUtilTest
    {
        [TestMethod]
        public  void CanAppendTimeToDate()
        {
            var date = DateTime.Now.Date;
            var time = "01:00 PM";
            var appendedDate = date.AppendTime(time);
            Assert.AreEqual(date.Year, appendedDate.Year);
            Assert.AreEqual(date.Month, appendedDate.Month);
            Assert.AreEqual(date.Day, appendedDate.Day);
            Assert.AreEqual(13,appendedDate.Hour);
            Assert.AreEqual(0,appendedDate.Minute);
        }
    }
}
