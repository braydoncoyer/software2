using Software2.DTO;
using System;
using System.Collections.Generic;

namespace Software2.Forms
{
    public class CustomerService
    {
        CustomerRepository _repo = new CustomerRepository();
        public CustomerService()
        {
        }

        public List<customerDTO> getCustomers()
        {
            var customers = _repo.getCustomers();
            List<customerDTO> customerDTOs = new List<customerDTO>();
            foreach(var c in customers)
            {
                var dto = new customerDTO();
                dto.name = c.customerName;
                dto.address1 = c.address.address1;
                dto.address2 = c.address.address2;
                dto.city = c.address.city.city1;
                dto.zipcode = c.address.postalCode;
                dto.phone = c.address.phone;
                dto.id = c.customerId;
                customerDTOs.Add(dto);
            }
            return customerDTOs;
        }
    }
}