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
        public string contact { get; set; }
        public string url { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public int appointmentId { get; set; }
        public int customerId { get; set; }
    }
}
