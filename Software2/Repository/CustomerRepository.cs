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
    }
}