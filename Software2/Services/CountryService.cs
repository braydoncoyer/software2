using Software2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class CountryService
    {
        CountryRepository _cr;

        public CountryService()
        {
            _cr = new CountryRepository();
        }

        public List<country> findAllCountries()
        {
            return _cr.findAllCountries();
        }

        public country findByCountryId(int id)
        {
            return _cr.findByCountryId(id);
        }

        public void updateCountry(country country)
        {
            _cr.updateCountry(country);
        }

        public void deleteCountry(country country)
        {
            _cr.deleteCountry(country);
        }

        public void deleteCountryById(int id)
        {
            _cr.deleteCountryById(id);
        }

        public country createCountry(country country)
        {
            return _cr.createCountry(country);
        }
    }
}
