using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShipCruiseManagementSystem.Models
{
    public class User
    {
        private string Password { get; set; }
        private string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }
       

        public User() { }

        public User(string password, string userName)
        {
            Password = password;
            UserName = userName;
        }

        public User GetUserAcount()
        {


            return null;
        }

    }
}
