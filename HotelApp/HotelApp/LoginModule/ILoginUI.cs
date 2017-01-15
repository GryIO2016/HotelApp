using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.LoginModule
{
    public interface ILoginUI
    {
        User LogIn(string email, string password);
        List<User> ListUsers();
        bool RegisterUser(string name, string lastName, DateTime birthDate, string phone, string email, string password, string pesel, EnumHelper.Role role);
        bool EditUser(User oldUser, string name, string lastName, DateTime birthDate, string phone, string email, string password, string pesel, EnumHelper.Role role);
        bool EditUser(User oldUser, string name, string lastName, DateTime birthDate, string phone, string email, string pesel, EnumHelper.Role role);
    }
}
