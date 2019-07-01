using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Demo.Scripts.model
{
    public class User : IUser
    {
        public  string username { get; set; }
        public string password { get; set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }


}
