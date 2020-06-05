using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginCustomList.Domain;
using UserLoginCustomList.List;

namespace UserLoginCustomList.Repository
{
    public class UserRepository
    {
        private CustomLinkedList<User> _users = new CustomLinkedList<User>();

        public UserRepository()
        {
            InitializeList();
        }

        public User findUserByNamePassword(String username, String password)
        {
            foreach (User user in _users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    return user;
                }
            }

            return null;
        }

        public User findByName(String username)
        {
            foreach (User user in _users)
            {
                if (user.Username.Equals(username))
                {
                    return user;
                }
            }

            return null;
        }

        public bool deleteUser(User user)
        {
            return _users.Remove(user);
        }

        public void insertUser(User user)
        {
            _users.Add(user);
        }

        private void InitializeList()
        {
            User[] users = new User[]
            {
                new User(1, "GeorgiIvanov", "georgii1234", "121217100", UserRole.STUDENT, DateTime.Now, DateTime.Now.AddYears(4)),
                new User(2, "IvanGeorgiev", "ivang567", "121217154", UserRole.STUDENT, DateTime.Now, DateTime.Now.AddYears(2)),
                new User(3, "PeterPetrov", "peterp34", null, UserRole.ADMIN, DateTime.Now, default(DateTime)),
                new User(4, "IvayloBozhinov", "ivaylob00", null, UserRole.PROFESSOR, DateTime.Now, default(DateTime)),
                new User(5, "StefanKirilov", "stefankkk", "121217112", UserRole.STUDENT, DateTime.Now, DateTime.Now.AddYears(3)),
                new User(6, "NikolaKrustev", "nikokrustev", "121217091", UserRole.STUDENT, DateTime.Now, DateTime.Now.AddYears(1))
            };

            foreach(User user in users)
            {
                _users.Add(user);
            }
        }
    }
}
