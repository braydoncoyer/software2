using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repository
{
    public class AddressRepository
    {
        U04uzGEntities _db;

        public AddressRepository()
        {
            _db = new U04uzGEntities();
        }

        public address findByAddressId(int id)
        {
            return _db.addresses.FirstOrDefault(a => a.addressId == id);
        }

        public void updateAddress(address address)
        {
            var updateAddress = findByAddressId(address.addressId);
            updateAddress = address;
            _db.SaveChanges();
        }

        public void deleteAddress(address address)
        {
            _db.addresses.Remove(address);
            _db.SaveChanges();
        }

        public address createAddress(string address1, string address2, string cityId, string zipcode, string phoneNumber)
        {
            var address = new address();
            var maxId = _db.addresses.Max(id => id.addressId);
            address.addressId = maxId + 1;
            address.address1 = address1;
            address.address2 = address2;
            address.cityId = int.Parse(cityId);
            address.phone = phoneNumber;
            address.postalCode = zipcode;
            address.createDate = DateTime.Now;
            address.createdBy = "braydon";
            address.lastUpdate = DateTime.Now;
            address.lastUpdateBy = "braydon";

            _db.addresses.Add(address);
            _db.SaveChanges();
            return _db.addresses.FirstOrDefault(a => a.addressId == address.addressId);
        }
    }
}
