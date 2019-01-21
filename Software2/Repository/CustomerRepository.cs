using System;
using System.Collections.Generic;
using System.Linq;

namespace Software2.Forms
{
    public class CustomerRepository
    {
        U04uzGEntities db = new U04uzGEntities();
        private string username;

        public CustomerRepository(string username)
        {
            this.username = username;
        }

        public List<customer> getCustomers()
        {
            return db.customers.ToList();
        }

        public customer getCustomerDTOByID(int customerID)
        {
            return db.customers.FirstOrDefault(c => c.customerId == customerID);
        }

        public void updateCustomer(customer updatedCustomer)
        {
            updatedCustomer.lastUpdate = DateTime.Now;
            var oldCustomer = this.getCustomerDTOByID(updatedCustomer.customerId);
            oldCustomer = updatedCustomer;
            db.SaveChanges();
        }

        public country createNewCountry(string country)
        {
            country newCountry = new country();
            newCountry.country1 = country;
            newCountry.countryId = (db.countries.OrderByDescending(c => c.countryId).FirstOrDefault().countryId) + 1;
            newCountry.createDate = DateTime.Now;
            newCountry.createdBy = this.username;
            newCountry.lastUpdate = DateTime.Now;
            newCountry.lastUpdateBy = this.username;
            db.countries.Add(newCountry);
            db.SaveChanges();
            return newCountry;
        }

        public city createNewCity(string city, country country)
        {
            city newCity = new city();
            newCity.city1 = city;
            // This lambda finds the largest cityID in the table, and adds 1 to it to create a new city ID for this city.
            newCity.cityId = (db.cities.OrderByDescending(c => c.cityId).FirstOrDefault().cityId) + 1;
            newCity.createDate = DateTime.Now;
            newCity.createdBy = this.username;
            newCity.lastUpdate = DateTime.Now;
            newCity.lastUpdateBy = this.username;
            newCity.country = country;
            db.cities.Add(newCity);
            db.SaveChanges();
            return newCity;
        }

        internal void deleteCustomer(int customerID)
        {
            var customerToDelete = getCustomerDTOByID(customerID);
            if(customerToDelete.appointments.Count > 0)
            {
                throw new Exception("Cannot delete customer that is attached to an appointment");
            }
            db.customers.Remove(customerToDelete);
            db.SaveChanges();
        }

        public address createNewAddress(address newAddress)
        {
            newAddress.addressId = (db.addresses.OrderByDescending(a => a.addressId).FirstOrDefault().addressId) + 1;
            newAddress.createDate = DateTime.Now;
            newAddress.createdBy = this.username;
            newAddress.lastUpdate = DateTime.Now;
            newAddress.lastUpdateBy = this.username;
            db.addresses.Add(newAddress);
            db.SaveChanges();
            return newAddress;
        }

        internal void createCustomer(customer newCustomer)
        {
            newCustomer.customerId = (db.customers.OrderByDescending(c => c.customerId).FirstOrDefault().customerId) + 1;
            newCustomer.lastUpdate = DateTime.Now;
            newCustomer.lastUpdateBy = this.username;
            newCustomer.createDate = DateTime.Now;
            newCustomer.createdBy = this.username;
            db.customers.Add(newCustomer);
            db.SaveChanges();
        }

        public string getCustomerNameByID(int dataID)
        {
            var customer = db.customers.FirstOrDefault(c => c.customerId == dataID);
            return customer.customerName;
        }
    }
}