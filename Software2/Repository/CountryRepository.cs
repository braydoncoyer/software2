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

        public country createCountry(country country)
        {
            _db.countries.Add(country);
            _db.SaveChanges();
            return _db.countries.FirstOrDefault(c => c.countryId == country.countryId);
        }
    }
}
