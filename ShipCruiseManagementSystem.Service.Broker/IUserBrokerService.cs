using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipCruiseManagementSystem.Services.Inter;


namespace ShipCruiseManagementSystem.Service.Broker
{
    public interface IUserBrokerService
    {

      IUserService Proxy { get; set; }
    }
}
