using System;
using Software2;
using Software2.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCustomerReturnsLegolas()
        {
            var CustomerService = new CustomerService();
            var customer = CustomerService.findCustomerById(1);
            Assert.AreEqual("Gimli", customer.customerName);
        }

        [TestMethod]
        public void UpdatedCustomerNameReturnsGimli()
        {
            var CustomerService = new CustomerService();
            var customer = CustomerService.findCustomerById(1);
            customer.customerName = "Gimli";
            CustomerService.updateCustomer(customer);
            var updatedCustomer = CustomerService.findCustomerById(1);
            Assert.AreEqual("Gimli", updatedCustomer.customerName);
        }

        [TestMethod]
        public void DeleteCustomerShouldReturnNull()
        {
            var CustomerService = new CustomerService();
            var customer = CreateCustomer();
            CustomerService.CreateCustomer(customer);
            CustomerService.DeleteCustomer(customer);
            var deletedCustomer = CustomerService.findCustomerById(customer.customerId);
            Assert.IsNull(deletedCustomer);
        }

        [TestMethod]
        public void CreateCustomerShouldReturnAragorn()
        {
            var CustomerService = new CustomerService();
            customer customer = CreateCustomer();
            var newCustomer = CustomerService.CreateCustomer(customer);
            Assert.AreEqual("Aragorn", newCustomer.customerName);
        }

        private static customer CreateCustomer()
        {
            var customer = new customer();
            Random rnd = new Random();
            customer.customerId = rnd.Next(2,900);
            customer.customerName = "Aragorn";
            customer.addressId = 1;
            customer.active = true;
            customer.createdBy = "braydon";
            customer.createDate = DateTime.Now;
            customer.lastUpdate = DateTime.Now;
            customer.lastUpdateBy = "braydon";
            return customer;
        }
    }
}
