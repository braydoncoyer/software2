using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.DTO
{
    public class customerDTO
    {
            public string name { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string zipcode { get; set; }
            public string phone { get; set; }
        public int id { get; internal set; }
    }
}
