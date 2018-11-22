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
            dto.address = c.address.address1;
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
            checkAddressForUpdates(customerDTO, updatedCustomer);
            updatedCustomer.customerName = customerDTO.name;
            updatedCustomer.lastUpdateBy = this.username;
            _repo.updateCustomer(updatedCustomer);
        }

        public void checkAddressForUpdates(customerDTO customerDTO, customer updatedCustomer)
        {
            if(!string.Equals(customerDTO.country, updatedCustomer.address.city.country))
            {
                var newCountry = _repo.createNewCountry(customerDTO.country);
            }
        }
    }
}