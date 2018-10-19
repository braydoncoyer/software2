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
        public city findByCityName(string name, int countryID)
        {
            try
            {
                return _db.cities.Where(city => city.city1 == name && city.countryId == countryID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // no city found.
                return null;
            }
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

        public city createCity(string cityName, int countryId, DateTime createdDate, DateTime lastUpdate, string lastUpdateBy)
        {
            var city = new city();
            var maxId = _db.cities.Max(id => id.cityId);
            city.cityId = maxId + 1;
            city.city1 = cityName;
            city.countryId = countryId;
            city.createDate = DateTime.Now.ToUniversalTime();
            city.createdBy = "braydon";
            city.lastUpdate = DateTime.Now.ToUniversalTime();
            city.lastUpdateBy = lastUpdateBy;
            _db.cities.Add(city);
            _db.SaveChanges();
            return _db.cities.FirstOrDefault(c => c.cityId == city.cityId);
        }

        public List<city> findAll()
        {
            var cities = _db.cities.AsEnumerable();
            if (cities == null)
            {
                return new List<city>();
            }
            return cities.ToList();
        }
    }
}
