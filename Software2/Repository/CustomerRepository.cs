using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repository
{
    public class CustomerRepository
    {
        U04uzGEntities _db;

        public CustomerRepository()
        {
            _db = new U04uzGEntities();
        }

        public customer findByCustomerId(int id)
        {
            return _db.customers.FirstOrDefault(c => c.customerId == id);
        }

        public void updateCustomer(customer customer)
        {
            var updateCustomer = findByCustomerId(customer.customerId);
            updateCustomer = customer;
            _db.SaveChanges();
        }

        public void DeleteCustomer(customer customer)
        {
            _db.customers.Remove(customer);
            _db.SaveChanges();
        }

        public customer CreateCustomer(customer customer)
        {
            _db.customers.Add(customer);
            _db.SaveChanges();
            return _db.customers.FirstOrDefault(c => c.customerId == customer.customerId);
        }
    }
}
