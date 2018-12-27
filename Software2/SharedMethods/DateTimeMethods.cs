using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.SharedMethods
{
    public static class DateTimeMethods
    {
        public static DateTime ConvertToUniversalTime(DateTime _dateTime)
        {
            return new DateTime(_dateTime.ToUniversalTime().Ticks, DateTimeKind.Utc);
        }
    }
}
