using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.LoginModule
{
    public class Logger : ILoginUI
    {
        private ILogging dataBase = new DBManagment();
        private bool Exists(string email)
        {
            User test = dataBase.findUser(email);
            if (test!=null) return true;
            else return false;
        }
        public User LogIn(string email, string password)
        {
            User user = dataBase.findUser(email, password);
            if (user!=null)
            {
                return user;
            }
            else return user;
        }
        public bool RegisterUser(string name, string lastName, DateTime birthDate, string phone, string email, string password, string pesel, EnumHelper.Role role)
        {
            if (Exists(email))
            {
                return false;    //this means that there already IS user with the given e-mail address
            }
            else
            {
                User newUser = new User(name, lastName, birthDate, phone, email, password, pesel, role);
                dataBase.addUser(newUser);
                return true;   //everything went good
            }
        }
    }
}
