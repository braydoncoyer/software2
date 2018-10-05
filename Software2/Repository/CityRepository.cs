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

        public city createCity(string cityName, string countryId, DateTime createdDate, DateTime lastUpdate, string lastUpdateBy)
        {
            var city = new city();
            var maxId = _db.cities.Max(id => id.cityId);
            city.cityId = maxId + 1;
            city.city1 = cityName;
            city.countryId = 999;
            city.createDate = DateTime.Now;
            city.createdBy = "braydon";
            city.lastUpdate = DateTime.Now;
            city.lastUpdateBy = lastUpdateBy;
            _db.cities.Add(city);
            _db.SaveChanges();
            return _db.cities.FirstOrDefault(c => c.cityId == city.cityId);
        }
    }
}
