using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginCustomList.Domain
{
    public class User
    {
        public Int32 UserId { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        public String FacultyNumber { get; set; }

        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ActiveUnitl { get; set; }

        public User() { }

        public User(Int32 id, String username, String password, String fn, UserRole role, DateTime creation, DateTime expiration)
        {
            UserId = id;
            Username = username;
            Password = password;
            FacultyNumber = fn;
            Role = role;
            CreatedAt = creation;
            ActiveUnitl = expiration;
        }
    }
}
