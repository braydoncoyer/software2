using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repository
{
    public class CalendarRepository
    {
        U04uzGEntities _db = new U04uzGEntities();
        public user findUser(int id)
        {
            return _db.users.Find(id);
        }

        public user findByUsername(String username)
        {
            return _db.users.FirstOrDefault(p => p.userName.Equals(username));
        }

        public void addUser(user user)
        {
            _db.users.Add(user);
            _db.SaveChanges();
        }

        public void updateUser(user updateUser, int id)
        {
            var _user = this.findUser(id);
            _user = updateUser;
            _db.SaveChanges();
        }

        public void deleteUser(int id)
        {
            var _deleteUser = this.findUser(id);
            _db.users.Remove(_deleteUser);
        }



    }
}
