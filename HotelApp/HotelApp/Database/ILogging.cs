using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public interface ILogging
    {
        void addUser(User user);
        void editUser(User oldUser, User newUser);
        User findUser(String email);
        User findUser(String email, String password);
    }
}
