using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repository
{
    public class CityRepository
    {

        U04uzGEntities _db;

        public CityRepository()
        {
            _db = new U04uzGEntities();
        }

        public city findByCityId(int id)
        {
            return _db.cities.FirstOrDefault(c => c.cityId == id);
        }

        public void updateCity(city city)
        {
            var updateCity = findByCityId(city.cityId);
            updateCity = city;
            _db.SaveChanges();
        }

        public void deleteCity(city city)
        {
            _db.cities.Remove(city);
            _db.SaveChanges();
        }

        public void deleteCityById(int id)
        {
           var city = findByCityId(id);
            deleteCity(city);
        }

        public city createCity(city city)
        {
            _db.cities.Add(city);
            _db.SaveChanges();
            return _db.cities.FirstOrDefault(c => c.cityId == city.cityId);
        }
    }
}
