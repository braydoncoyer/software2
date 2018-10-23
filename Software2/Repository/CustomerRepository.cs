using Software2.Models;
using Software2.Models.Exceptions;
using Software2.Services;
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
        private AddressRepository addressRespository = new AddressRepository();
        U04uzGEntities _db;
        private CustomerService _customerService;

        public CustomerRepository(string username)
        {
            this.username = username;
            _db = new U04uzGEntities();
        }

        public List<customer> FindAllCustomers()
        {
            return _db.customers.ToList();
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

        public IEnumerable<CustomerAggregate> FindAllAggregates()
        {
            var customers = FindAll();
            var addressAggregates = addressRespository.FindAllAggregates();
            var customerAggregates = new List<CustomerAggregate>();

            foreach (var customer in customers)
            {
                var addressId = customer.addressId;
                var addressAggregate = addressAggregates.FirstOrDefault(a => a.AddressId == addressId);
                customerAggregates.Add(new CustomerAggregate()
                {
                    Id = customer.customerId,
                    AddressId = customer.addressId,
                    Address1 = addressAggregate.Address1,
                    Address2 = addressAggregate.Address2,
                    City = addressAggregate.CityName,
                    CityId = addressAggregate.CityId,
                    Country = addressAggregate.CountryName,
                    CountryId = addressAggregate.CountryId,
                    CustomerName = customer.customerName,
                    Phone = addressAggregate.Phone,
                    PostalCode = addressAggregate.PostalCode
                });
            }

            return customerAggregates;
        }

        public void Add(CustomerAggregate aggregate)
        {
            if (String.IsNullOrWhiteSpace(aggregate.CustomerName))
                throw new InvalidInputException("Must include name");

            var date = DateTime.Now;
            var customerToAdd = new customer()
            {
                active = true,
                addressId = aggregate.AddressId,
                createDate = date,
                lastUpdate = date,
                createdBy = "braydon",
                lastUpdateBy = "braydon",
                customerName = aggregate.CustomerName,
            };

            _db.customers.Add(customerToAdd);

        }

        public IEnumerable<customer> FindAll()
        {
            return _db.customers.AsEnumerable();
        }
    }
}
