﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Models.Exceptions
{
    class NotFoundException : Exception
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {

        }
    }
}