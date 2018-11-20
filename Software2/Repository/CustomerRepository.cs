using System;
using System.Collections.Generic;
using System.Linq;

namespace Software2.Forms
{
    public class CustomerRepository
    {
        U04uzGEntities db = new U04uzGEntities();
        public List<customer> getCustomers()
        {
            return db.customers.ToList();
        }
    }
}