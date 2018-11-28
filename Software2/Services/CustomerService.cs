using Software2.DTO;
using System;
using System.Collections.Generic;

namespace Software2.Forms
{
    public class CustomerService
    {
        CustomerRepository _repo;
        string username;
        public CustomerService(string username)
        {
            this.username = username;
            _repo = new CustomerRepository(this.username);
        }

        public List<customerDTO> getCustomers()
        {
            var customers = _repo.getCustomers();
            List<customerDTO> customerDTOs = new List<customerDTO>();
            foreach(var c in customers)
            {
                var dto = mapDTO(c);
                customerDTOs.Add(dto);
            }
            return customerDTOs;
        }

        public customerDTO mapDTO(customer c)
        {
            var dto = new customerDTO();
            dto.name = c.customerName;
            dto.address1 = c.address.address1;
            dto.address2 = c.address.address2;
            dto.city = c.address.city.city1;
            dto.country = c.address.city.country.country1;
            dto.zipcode = c.address.postalCode;
            dto.phone = c.address.phone;
            dto.id = c.customerId;
            return dto;
        }

        public customerDTO getCustomerByID(int customerID)
        {
            var customer = _repo.getCustomerByID(customerID);
            var dto = mapDTO(customer);
            return dto;
        }

        public void updateCustomer(customerDTO customerDTO)
        {
            var updatedCustomer = _repo.getCustomerByID(customerDTO.id);
            updatedCustomer = checkAddressForUpdates(customerDTO, updatedCustomer);
            updatedCustomer.customerName = customerDTO.name;
            updatedCustomer.lastUpdateBy = this.username;
            _repo.updateCustomer(updatedCustomer);
        }

        public customer checkAddressForUpdates(customerDTO customerDTO, customer updatedCustomer)
        {
            var oldCountry = updatedCustomer.address.city.country;
            var oldCity = updatedCustomer.address.city;
            var changed = false;

            if (!string.Equals(customerDTO.country, updatedCustomer.address.city.country.country1))
            {
                changed = true;
               oldCountry = _repo.createNewCountry(customerDTO.country);
            }
            if(!string.Equals(customerDTO.city, updatedCustomer.address.city.city1))
            {
                changed = true;
                oldCity = _repo.createNewCity(customerDTO.city, oldCountry);
            }
            if(!string.Equals(customerDTO.address1, updatedCustomer.address.address1) || 
                !string.Equals(customerDTO.address2, updatedCustomer.address.address2) ||
                changed)
            {
                // TODO: Figure out how to refresh CustomerList grid to update listings.
                address newAddress = new address();
                newAddress.address1 = customerDTO.address1;
                newAddress.address2 = customerDTO.address2;
                newAddress.city = oldCity;
                newAddress.city.country = oldCountry;
                newAddress.phone = customerDTO.phone;
                newAddress.postalCode = customerDTO.zipcode;
                updatedCustomer.address = _repo.createNewAddress(newAddress);
            }

            return updatedCustomer;
        }
    }
}