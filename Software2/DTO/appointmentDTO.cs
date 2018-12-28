using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.DTO
{
    public class appointmentDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string customerName { get; set; }
        public int appointmentID { get; set; }
    }
}
