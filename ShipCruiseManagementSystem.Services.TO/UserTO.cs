using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ShipCruiseManagementSystem.Services.TO
{
    [DataContract]
   
    public class UserTO
    {
        [DataMember]
        public string PassWord { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public bool Deleted { get; set; }
        [DataMember]
        public DateTime DateCreated { get; set; }

    }
}
