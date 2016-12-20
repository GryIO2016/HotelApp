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
        public String Pesel { get; set; }
        public EnumHelper.Role Role { get; set; }

        public User()
        { }

        public User(int id, String name, String lastName, DateTime birthDate, String phone, string email, String password, String pesel, EnumHelper.Role role)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Password = password;
            Pesel = pesel;
            Role = role;
        }

        public User(String name, String lastName, DateTime birthDate, String phone, string email, String password, String pesel, EnumHelper.Role role)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Password = password;
            Pesel = pesel;
            Role = role;
        }

        public override string ToString()
        {
            return ("User " + Id + ": " + Name + " " + LastName + ", " + BirthDate + ", " + Phone + ", "
                + Email + ", " + Password + ", " + Pesel + ", " + Role);
        }

    }
}
