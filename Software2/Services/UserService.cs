using Software2.Repository;
using Software2.SharedMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Software2.Services
{
    public class UserService
    {
        CalendarRepository _repo = new CalendarRepository();

        public user findUser(int id)
        {
           var _user = _repo.findUser(id);
            if(_user == null)
            {
                throw new Exception("That user could not be found");
            }
            else
            {
                return _user;
            }
        }

        public List<user> getUsers()
        {
            return _repo.getUsers();
        }

        public user findByUsername(String username)
        {
            if(username == null)
            {
                throw new Exception("Please enter a username");
            }
            else
            {
                var _user = _repo.findByUsername(username);
                return _user;
            }
        }

        public void addUser(user user)
        {
            user _existingUser = _repo.findByUsername(user.userName);
            if(_existingUser == null)
            {
                //checks for required fields
                if(user.userName == null || user.password == null)
                {
                    user.lastUpdate = DateTimeMethods.ConvertToUniversalTime(DateTime.Now); ;
                    _repo.addUser(user);
                }
            }
        }

        public void updateUser(user updateUser, int id)
        {
            //Add checks for required fields?

            updateUser.lastUpdate = DateTimeMethods.ConvertToUniversalTime(DateTime.Now); ;
            _repo.updateUser(updateUser, id);
        }

        public void deleteUser(int id)
        {
            //Does this user have appointments made? Perhaps you cannot delete user if they have appointments made
            _repo.deleteUser(id);
        }

        public void login(String username, String password)
        {
            user _loginUser = _repo.findByUsername(username);

            //Login
            if (_loginUser == null)
            {
                throw new Exception("The username is incorrect.");
            }
            else if(_loginUser.password != password)
            {
                throw new Exception("The password was incorrect");;
            }
        }
    }
}
