using HotelApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.UI
{
    public class ActiveUser
    {
        public User CurrentUser { get; set; }
        private static ActiveUser instance;

        private ActiveUser() { }

        public static ActiveUser Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new ActiveUser();
                }
                return instance;
            }
        }
    }
}
