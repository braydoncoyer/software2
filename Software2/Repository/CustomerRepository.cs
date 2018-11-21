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

        public customer getCustomerByID(int customerID)
        {
            return db.customers.FirstOrDefault(c => c.customerId == customerID);
        }

        public void updateCustomer(customer updatedCustomer)
        {
            updatedCustomer.lastUpdate = DateTime.Now;
            var oldCustomer = this.getCustomerByID(updatedCustomer.customerId);
            oldCustomer = updatedCustomer;
            db.SaveChanges();
        }
    }
}