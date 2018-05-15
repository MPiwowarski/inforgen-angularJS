using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.SqlServerModel.Helpers
{
    public class TimestampHelper
    {
        public static byte[] Generate()
        {
            var timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return BitConverter.GetBytes(timestamp);
        }
    }
}
