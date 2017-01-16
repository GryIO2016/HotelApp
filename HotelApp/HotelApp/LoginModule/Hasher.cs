using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liphsoft.Crypto.Argon2;

namespace HotelApp.LoginModule
{
    class Hasher
    {
        public string Encode(string text)
        {
            var haszer = new PasswordHasher();
            string answer = haszer.Hash(text, "6BZ1sOqiVLqAWvnG1hKa");
            return answer;
        }
        public string OldEncode (string text)
        {
            int odpowiedz = text.GetHashCode();
            string answer = odpowiedz.ToString();
            return answer;
        }
        
    }
}
