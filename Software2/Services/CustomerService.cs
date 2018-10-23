using Software2.Models;
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
        private string username;
        CustomerRepository _cr;

        public CustomerService(string username)
        {
            this.username = username;
            _cr = new CustomerRepository(username);
        }

        public List<customer> FindAllCustomers()
        {
            return _cr.FindAllCustomers();
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

        public customer CreateCustomer(string customerName, Boolean active, string createdBy, DateTime createDate, DateTime lastUpdate, string lastUpdateBy, int addressID)
        {
            return _cr.CreateCustomer(customerName, active, createdBy, createDate, lastUpdate, lastUpdateBy, addressID);
        }

        public void Add(CustomerAggregate customerAggregate)
        {
            _cr.Add(customerAggregate);
        }

        public IEnumerable<customer> FindAll()
        {
            return _cr.FindAll();
        }
    }
    }
