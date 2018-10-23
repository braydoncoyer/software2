using Software2.Models;
using Software2.Models.Exceptions;
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
        private AddressRepository _addressRepository;

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

        public address FindByAddressAndPostalCode(string address1, string address2, string postalCode)
        {
            //if (String.IsNullOrEmpty(address1) || String.IsNullOrEmpty(postalCode))
            //    throw new InvalidInputException("Must supply address and postal code");
            var addresses = _addressRepository.FindAll();

            //Use lambda to filter the list of entities using multiple criteria and return the first matching record
            var existingAddress = addresses.Where(a => a.address1.Equals(address1, StringComparison.CurrentCultureIgnoreCase)
            && a.address2.Equals(address2, StringComparison.CurrentCultureIgnoreCase) && a.postalCode.Equals(postalCode)).FirstOrDefault();
            //if (existingAddress == null)
            //    throw new NotFoundException("Could not find specified address");
            return existingAddress;
        }


        public void update(address address)
        {
            var updateAddress = findByAddressId(address.addressId);
            updateAddress = address;
            _db.SaveChanges();
        }

        public void UpdateAddress(AddressAggregate addressAggregate)
        {
            var countryId = GetUpdatedCountryId(addressAggregate.CountryName);
            var cityId = GetUpdatedCityId(addressAggregate.CityId, addressAggregate.CityName, countryId);

            var existingAddress = FindByAddressAndPostalCode(addressAggregate.Address1, addressAggregate.Address2, addressAggregate.PostalCode);

            var address = new address()
            {
                cityId = cityId,
                address1 = addressAggregate.Address1,
                address2 = addressAggregate.Address2,
                addressId = addressAggregate.AddressId,
                phone = addressAggregate.Phone,
                postalCode = addressAggregate.PostalCode,
                createdBy = existingAddress.createdBy,
                createDate = existingAddress.createDate,
                lastUpdate = DateTime.Now.ToUniversalTime(),
                lastUpdateBy = "bryadon" //_authRepository.Username
            };

            _addressRepository.update(address);
        }

        public void deleteAddress(address address)
        {
            _db.addresses.Remove(address);
            _db.SaveChanges();
        }

        private int GetUpdatedCountryId(string countryName)
        {
            try
            {
                var country = _countryRepository.findByName(countryName);
                return country.countryId;

            }
            catch (NotFoundException e)
            {
                _countryRepository.Add(new country()
                {
                    country1 = countryName
                });
                var newCountry = _countryRepository.findByName(countryName);
                return newCountry.countryId;
            }
        }

        private int GetUpdatedCityId(int cityId, string cityName, int countryId)
        {
            try
            {
                var city = _cityRepository.findByNameAndCountryId(cityName, countryId);
                return city.cityId;
            }
            catch (NotFoundException e)
            {
                _cityRepository.Add(new city()
                {
                    city1 = cityName,
                    countryId = countryId
                });
                var newCity = _cityRepository.findByNameAndCountryId(cityName, countryId);
                return newCity.cityId;
            }
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

        public void addNewAddress(AddressAggregate addressAggregate)
        {
            ValidateAddressAggregate(addressAggregate);
            var username = "Braydon";
            try
            {
                var existingAddress = FindByAddressAndPostalCode(addressAggregate.Address1, addressAggregate.Address2, addressAggregate.PostalCode);
                //Already exists
                throw new DataIntegrityViolationException("Address already exists");
            }
            catch (NotFoundException e)
            {
                try
                {
                    var country = _countryRepository.findByName(addressAggregate.CountryName);
                    addressAggregate.CountryId = country.countryId;
                }
                catch (NotFoundException ex)
                {
                    _countryRepository.Add(new country()
                    {
                        country1 = addressAggregate.CountryName,
                        lastUpdate = DateTime.Now.ToUniversalTime(),
                        createdBy = username,
                        lastUpdateBy = username,
                        createDate = DateTime.Now.ToUniversalTime()
                    });

                    var country = _countryRepository.findByName(addressAggregate.CountryName);
                    addressAggregate.CountryId = country.countryId;
                }


                try
                {
                    var city = _cityRepository.findByNameAndCountryId(addressAggregate.CityName, addressAggregate.CountryId);
                    addressAggregate.CityId = city.cityId;
                }
                catch (NotFoundException ex)
                {
                    _cityRepository.Add(new city()
                    {
                        countryId = addressAggregate.CountryId,
                        city1 = addressAggregate.CityName,
                        lastUpdateBy = username,
                        createdBy = username,
                        createDate = DateTime.Now.ToUniversalTime(),
                        lastUpdate = DateTime.Now.ToUniversalTime()
                    });

                    var city = _cityRepository.findByNameAndCountryId(addressAggregate.CityName, addressAggregate.CountryId);
                    addressAggregate.CityId = city.cityId;
                }

               var newAddress = new address()
                {
                    cityId = addressAggregate.CityId,
                    address1 = addressAggregate.Address1,
                    address2 = addressAggregate.Address2,
                    createDate = DateTime.Now.ToUniversalTime(),
                    lastUpdate = DateTime.Now.ToUniversalTime(),
                    createdBy = username,
                    lastUpdateBy = username,
                    phone = addressAggregate.Phone,
                    postalCode = addressAggregate.PostalCode
                };

                _db.addresses.Add(newAddress);
            }
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

        private void ValidateAddressAggregate(AddressAggregate addressAggregate)
        {
            if (String.IsNullOrEmpty(addressAggregate.CityName))
                throw new InvalidInputException("Must include city value");
            if (String.IsNullOrEmpty(addressAggregate.CountryName))
                throw new InvalidInputException("Must include country value");
            if (String.IsNullOrEmpty(addressAggregate.Address1))
                throw new InvalidInputException("Must include address value");
            if (String.IsNullOrEmpty(addressAggregate.PostalCode))
                throw new InvalidInputException("Must include postal code value");
            if (String.IsNullOrEmpty(addressAggregate.Phone))
                throw new InvalidInputException("Must include phone number value");
        }


    }
}
