using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public EnumHelper.Role Role { get; set; }

        public User(int id, String name, String lastName, DateTime birthDate, String phone, string email, String password, EnumHelper.Role role)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
