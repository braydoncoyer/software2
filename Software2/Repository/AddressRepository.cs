using Software2.Models;
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
        private CityRepository _cityRepository;
        private CountryRepository _countryRepository;

        public AddressRepository()
        {
            _db = new U04uzGEntities();
        }

        public address findByAddressId(int id)
        {
            return _db.addresses.Find(id);
        }

        public address findByAddressNameAndCityID(string address1, string address2, int cityID)
        {
            return _db.addresses.Where(address => address.address1 == address1 && address.address2 == address2 && address.cityId == cityID).FirstOrDefault();
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

        public address createAddress(string address1, string address2, int cityId, string zipcode, string phoneNumber)
        {
            var address = new address();
            var maxId = _db.addresses.Max(id => id.addressId);
            address.addressId = maxId + 1;
            address.address1 = address1;
            address.address2 = address2;
            address.cityId = cityId;
            address.phone = phoneNumber;
            address.postalCode = zipcode;
            address.createDate = DateTime.Now.ToUniversalTime();
            address.createdBy = "braydon";
            address.lastUpdate = DateTime.Now.ToUniversalTime();
            address.lastUpdateBy = "braydon";

            _db.addresses.Add(address);
            _db.SaveChanges();
            return _db.addresses.FirstOrDefault(a => a.addressId == address.addressId);
        }

        public IEnumerable<AddressAggregate> FindAllAggregates()
        {
            var addresses = FindAll();
            var cities = _cityRepository.findAll();
            var countries = _countryRepository.findAll();
            var addressAggregates = new List<AddressAggregate>();
            foreach (var address in addresses)
            {
                var city = cities.FirstOrDefault(c => c.cityId == address.cityId);
                var country = countries.FirstOrDefault(c => c.countryId == city.countryId);
                addressAggregates.Add(new AddressAggregate()
                {
                    CityId = city.cityId,
                    CityName = city.city1,
                    CountryId = country.countryId,
                    CountryName = country.country1,
                    Address1 = address.address1,
                    Address2 = address.address2,
                    Phone = address.phone,
                    PostalCode = address.postalCode,
                    AddressId = address.addressId
                });
            }

            return addressAggregates;
        }

        public IEnumerable<address> FindAll()
        {
            return _db.addresses.AsEnumerable();
        }


    }
}
