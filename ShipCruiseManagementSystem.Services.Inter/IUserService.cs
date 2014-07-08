using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using ShipCruiseManagementSystem.Services.TO;
using ShipCruiseManagementSystem.Models;

namespace ShipCruiseManagementSystem.Services.Inter
{
    [ServiceContract]
   public interface IUserService
    {
        [OperationContract]
        ActionResult SaveUser(UserTO user);


    }
}
