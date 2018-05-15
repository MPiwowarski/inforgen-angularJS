using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.SqlServerModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Tests.Helpers
{
    [TestClass]
    public class TimeStampHelperTests
    {
        [TestMethod]
        public void When_generates_random_time_stamp_checks_its_length()
        {
            var timeStamp = TimestampHelper.Generate();

            Assert.AreEqual(timeStamp.Length, 4);

        }
    }
}
