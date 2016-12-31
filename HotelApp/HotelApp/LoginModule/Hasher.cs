using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HotelApp.LoginModule
{
    class Hasher
    {
        private SHA1 haszer = new SHA1CryptoServiceProvider();

        public string Encode (string text)
        {
            int odpowiedz = text.GetHashCode();
            string answer = odpowiedz.ToString();
            return answer;
        }
    }
}
