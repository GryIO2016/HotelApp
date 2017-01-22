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
        private Hasher haszer = new Hasher();

        private bool Exists(string email)
        {
            User test = dataBase.findUser(email);
            if (test != null) return true;
            else return false;
        }

        public User LogIn(string email, string password)
        {
            User user = dataBase.findUser(email, haszer.Encode(password));
            if (user == null)
            {
                user = dataBase.findUser(email, haszer.OldEncode(password));
                if (user != null)
                {
                    EditUser(user, user.Name, user.LastName, user.BirthDate, user.Phone, user.Email, password, user.Pesel, user.Role);
                }
                else
                {
                    user = dataBase.findUser(email, password);
                    if (user != null)
                    {
                        EditUser(user, user.Name, user.LastName, user.BirthDate, user.Phone, user.Email, password, user.Pesel, user.Role);
                    }
                }
            }
            return user;
        }

        public bool RegisterUser(string name, string lastName, DateTime birthDate, string phone, string email, string password, string pesel, EnumHelper.Role role)
        {
            if (Exists(email))
            {
                return false;
            }
            else
            {
                password = haszer.Encode(password);
                User newUser = new User(name, lastName, birthDate, phone, email, password, pesel, role);
                dataBase.addUser(newUser);
                return true;
            }
        }

        public bool EditUser(User oldUser, string name, string lastName, DateTime birthDate, string phone, string email, string password, string pesel, EnumHelper.Role role)
        {
            User user = dataBase.findUser(oldUser.Email);
            if (user != null)
            {
                password = haszer.Encode(password);
                User newUser = new User(name, lastName, birthDate, phone, email, password, pesel, role);
                dataBase.editUser(oldUser, newUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditUser(User oldUser, string name, string lastName, DateTime birthDate, string phone, string email, string pesel, EnumHelper.Role role)
        {
            User user = dataBase.findUser(oldUser.Email);
            if (user != null)
            {
                User newUser = new User(name, lastName, birthDate, phone, email, oldUser.Password, pesel, role);
                dataBase.editUser(oldUser, newUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> ListUsers()
        {
            List<User> lista = new List<User>();
            lista = dataBase.AllUsers();
            return lista;
        }
    }
}
