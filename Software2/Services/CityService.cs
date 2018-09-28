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

        public city createCity(city city)
        {
            return _cr.createCity(city);
        }

    }
}
