using Software2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class CustomerService
    {
        CustomerRepository _cr;

        public CustomerService()
        {
            _cr = new CustomerRepository();
        }

        public customer findCustomerById(int id)
        {
            return _cr.findByCustomerId(id);
        }

        public void updateCustomer(customer customer)
        {
            _cr.updateCustomer(customer);
        }

        public void DeleteCustomer(customer customer)
        {
            _cr.DeleteCustomer(customer);
        }

        public void DeleteCustomerById(int id)
        {
           var customer = _cr.findByCustomerId(id);
           _cr.DeleteCustomer(customer);
        }

        public customer CreateCustomer(string customerName, Boolean active, string createdBy, DateTime createDate, DateTime lastUpdate, string lastUpdateBy)
        {
            return _cr.CreateCustomer(customerName, active, createdBy, createDate, lastUpdate, lastUpdateBy);
        }
    }
}
