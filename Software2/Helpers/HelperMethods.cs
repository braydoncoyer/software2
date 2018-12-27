using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Helpers
{
    class HelperMethods
    {

        public static DateTime ConvertToUniversalTime(DateTime dateTime)
        {
            return new DateTime(dateTime.ToUniversalTime().Ticks, DateTimeKind.Utc);
        }
    }
}
