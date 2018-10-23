using Software2.Models;
using Software2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class AddressService
    {
      
            AddressRepository _cr;

            public AddressService()
            {
                _cr = new AddressRepository();
            }

            public address findByAddressNameAndCityID(string address1, string address2, int cityID)
            {
            return _cr.findByAddressNameAndCityID(address1, address2, cityID);
            }

            public address findAddressById(int id)
            {
                return _cr.findByAddressId(id);
            }

            public address FindByAddressAndPostalCode(string address1, string address2, string postalCode)
            {
                return _cr.FindByAddressAndPostalCode(address1, address2, postalCode);
            }

            public void updateAddress(address address)
            {
                _cr.update(address);
            }

            public void UpdateAddress(AddressAggregate addressAggregate)
            {
             _cr.UpdateAddress(addressAggregate);
            }

            public void deleteAddress(address address)
            {
                _cr.deleteAddress(address);
            }

            public void deleteAddressById(int id)
            {
                var address = _cr.findByAddressId(id);
                _cr.deleteAddress(address);
            }

            public address createAddress(string address1, string address2, int cityId, string zipcode, string phoneNumber)
            {
                return _cr.createAddress(address1, address2, cityId, zipcode, phoneNumber);
            }

        public IEnumerable<address> FindAll()
        {
            return _cr.FindAll();
        }

        public void addNewAddress(AddressAggregate addressAggregate)
        {
            _cr.addNewAddress(addressAggregate);
        }
    }
}
