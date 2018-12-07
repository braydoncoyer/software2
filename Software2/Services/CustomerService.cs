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

        public List<customerDTO> getCustomerDTOs()
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

        public List<customer> getCustomers()
        {
            return _repo.getCustomers();
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

        internal void deleteCustomer(int customerID)
        {
            _repo.deleteCustomer(customerID);
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
                var newAddress = constructAddress(customerDTO, oldCity, oldCountry);
                updatedCustomer.address = _repo.createNewAddress(newAddress);
            }

            return updatedCustomer;
        }

        public void addCustomer(customerDTO customerDTO)
        {
            var country = _repo.createNewCountry(customerDTO.country);
            var city = _repo.createNewCity(customerDTO.city, country);
            var address = constructAddress(customerDTO, city, country);
            _repo.createNewAddress(address);

            customer newCustomer = new customer();
            newCustomer.address = address;
            newCustomer.address.city = city;
            newCustomer.address.city.country = country;
            newCustomer = mapDTOToCustomer(customerDTO, newCustomer);

            _repo.createCustomer(newCustomer);
        }

        public customer mapDTOToCustomer(customerDTO customerDTO, customer newCustomer)
        {
            newCustomer.active = true;
            newCustomer.customerName = customerDTO.name;
            return newCustomer;
        }

        private address constructAddress(customerDTO customerDTO, city city, country country)
        {
            address newAddress = new address();
            newAddress.address1 = customerDTO.address1;
            newAddress.address2 = customerDTO.address2;
            newAddress.phone = customerDTO.phone;
            newAddress.city = city;
            newAddress.city.country = country;
            newAddress.phone = customerDTO.phone;
            newAddress.postalCode = customerDTO.zipcode;
            return newAddress;

        }
    }
}