﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2
{
    class CustomerRow
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int AddressId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
