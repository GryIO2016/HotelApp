using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.LoginModule
{
    static class Logger : ILoginUI
    {
        private DBManagement dataBase = new DBManagement();
        bool Exists(string email)
        {
            if (dataBase.findUser(email)) return true;
            else return false;
        }
        User LogIn(string email, string password)
        {
            User user = dataBase.findUser(email, password);
            if (user)
            {
                return user;
            }
            else return user;
        }
        bool RegisterUser(string name, string lastName, DateTime birthDate, string phone, string email, string password, string pesel, EnumHelper.Role role)
        {
            if (Exists(email))
            {
                return true;    //this means that there already IS user with the given e-mail address
            }
            else
            {
                User newUser = new User(name, lastName, birthDate, phone, email, password, pesel, role);
                dataBase.addUser(newUser);
            }
        }
    }
}
