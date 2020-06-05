using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginCustomList.Domain;
using UserLoginCustomList.Repository;
using UserLoginCustomList.Validator;

namespace UserLoginCustomList.Service
{
    public class UserService
    {
        private UserRepository _repository;

        public UserService()
        {
            _repository = new UserRepository();
        }

        public User getUser(String username, String password)
        {
            return _repository.findUserByNamePassword(username, password);
        }

        public User getUser(String username)
        {
            return _repository.findByName(username);
        }

        public User changeUserRole(User user, UserRole role)
        {
            if (!_repository.deleteUser(user))
            {
                throw new ArgumentException("User does not exist");
            }

            user.Role = role;
            _repository.insertUser(user);

            return user;
        }

        public User updateUserExpiration(User user, DateTime expiration)
        {
            if (!_repository.deleteUser(user))
            {
                throw new ArgumentException("User does not exist");
            }

            user.ActiveUnitl = expiration;
            _repository.insertUser(user);

            return user;
        }
    }
}
