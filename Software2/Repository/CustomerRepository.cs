using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repository
{
    public class CustomerRepository
    {
        private string username;
        U04uzGEntities _db;

        public CustomerRepository(string username)
        {
            this.username = username;
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

        public customer CreateCustomer(string customerName, Boolean active, string createdBy, DateTime createDate, DateTime lastUpdate, string lastUpdateBy, int addressID)
        {
            var customer = new customer();
            customer.customerName = customerName;
            customer.active = active;
            customer.createDate = createDate;
            customer.createdBy = createdBy;
            customer.lastUpdate = lastUpdate;
            customer.lastUpdateBy = lastUpdateBy;
            var maxId = _db.customers.Max(id => id.customerId);
            customer.customerId = maxId + 1;
            customer.addressId = addressID;
            _db.customers.Add(customer);
            _db.SaveChanges();
            return _db.customers.FirstOrDefault(c => c.customerId == customer.customerId);
        }
    }
}
