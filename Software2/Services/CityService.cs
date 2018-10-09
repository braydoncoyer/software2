using Software2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class CityService
    {

        CityRepository _cr;

        public CityService()
        {
            _cr = new CityRepository();
        }

        public city findByCityName(string name, int countryID)
        {
            return _cr.findByCityName(name, countryID);
        }

        public city findCustomerById(int id)
        {
            return _cr.findByCityId(id);
        }

        public void updateCity(city city)
        {
            _cr.updateCity(city);
        }

        public void deleteCity(city city)
        {
            _cr.deleteCity(city);
        }

        public void deleteCityById(int id)
        {
            var city = _cr.findByCityId(id);
            _cr.deleteCity(city);
        }

        public city createCity(string cityName, int countryId, DateTime createdDate, DateTime lastUpdate, string lastUpdateBy)
        {
            return _cr.createCity(cityName, countryId, createdDate, lastUpdate, lastUpdateBy);
        }

    }
}
