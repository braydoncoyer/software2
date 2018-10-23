using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repository
{
    class CountryRepository
    {
        U04uzGEntities _db;
        public CountryRepository()
        {
            _db = new U04uzGEntities();
        }

        public List<country> findAllCountries()
        {
            return _db.countries.ToList();
        }

        public country findByName(string name)
        {
            try
            {
                return _db.countries.FirstOrDefault(country => country.country1 == name);
            }
            catch (Exception ex)
            {
                // no country found
                return null;
            }
        }

        public country findByCountryId(int id)
        {
            return _db.countries.Find(id);
        }

        public void updateCountry(country country)
        {
            var updateCountry = findByCountryId(country.countryId);
            updateCountry = country;
            _db.SaveChanges();
        }

        public void deleteCountry(country country)
        {
            _db.countries.Remove(country);
            _db.SaveChanges();
        }

        public void deleteCountryById(int id)
        {
            var country = findByCountryId(id);
            _db.countries.Remove(country);
            _db.SaveChanges();
        }

        public country createCountry(string country, string createdBy, DateTime createDate, DateTime lastUpdate, string lastUpdatedBy)
        {
            var newCountry = new country();
            var maxId = _db.countries.Max(id => id.countryId);
            newCountry.countryId = maxId + 1;
            newCountry.country1 = country;
            newCountry.createdBy = createdBy;
            newCountry.createDate = createDate;
            newCountry.lastUpdate = lastUpdate;
            newCountry.lastUpdateBy = lastUpdatedBy;
            _db.countries.Add(newCountry);
            _db.SaveChanges();
            return _db.countries.FirstOrDefault(c => c.countryId == newCountry.countryId);
        }

        public void Add(country country)
        {
            var maxId = _db.countries.Max(c => c.countryId);
            country.countryId = maxId + 1;
            _db.countries.Add(country);
            _db.SaveChanges();
        }

        public List<country> findAll()
        {
            var countries = _db.countries.AsEnumerable();
            if (countries == null)
            {
                return new List<country>();
            }
            return countries.ToList();
        }
    }
}
