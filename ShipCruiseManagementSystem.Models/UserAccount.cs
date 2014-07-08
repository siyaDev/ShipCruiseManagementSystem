using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipCruiseManagementSystem.Models
{
   public class UserAccount
   {
       public string UserName;
       public string PassWord;

       public UserAccount(){}

       public UserAccount(string username, string password)
       {
           UserName = username;
           PassWord = password;

       }

       public void SaveUser(int role)
       {

       }





   }
}
