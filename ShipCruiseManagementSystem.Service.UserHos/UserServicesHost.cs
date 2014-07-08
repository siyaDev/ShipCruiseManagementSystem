using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System;
using ShipCruiseManagementSystem.Services;
using ShipCruiseManagementSystem.Services.Inter;

namespace ShipCruiseManagementSystem.ServiceHost
{
    public class UserServicesHost
    {
        private string _host;
        private int _port;

        public UserServicesHost(string host, int port)
        {
            _host = host;
            _port = port;
        }
        public void Initialize()
        {
            try
            {
                var host = new System.ServiceModel.ServiceHost(typeof(UserServices));

                var binding = new NetTcpBinding
                {
                    MaxReceivedMessageSize = 2147483647,
                    MaxBufferPoolSize = 2147483647,
                    MaxBufferSize = 2147483647,
                    MaxConnections = 30000,
                    ReaderQuotas =
                    {
                        MaxBytesPerRead = 2147483647,
                        MaxDepth = 2147483647,
                        MaxArrayLength = 2147483647,
                        MaxNameTableCharCount = 2147483647,
                        MaxStringContentLength = 2147483647
                    }
                };

                binding.SendTimeout = binding.ReceiveTimeout = new TimeSpan(0, 2, 0);
                host.AddServiceEndpoint(typeof(UserServices), binding, string.Format("net.tcp://{0}:{1}", _host, _port));

                ServiceBehaviorAttribute serviceBehaviorAttribute = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
                if (serviceBehaviorAttribute != null)
                    serviceBehaviorAttribute.MaxItemsInObjectGraph = int.MaxValue;

                ServiceThrottlingBehavior serviceThrottlingBehavior = host.Description.Behaviors.Find<ServiceThrottlingBehavior>();
                if (serviceThrottlingBehavior == null)
                {
                    serviceThrottlingBehavior = new ServiceThrottlingBehavior
                        {
                            MaxConcurrentCalls = 400,
                            MaxConcurrentSessions = 64
                        };
                    host.Description.Behaviors.Add(serviceThrottlingBehavior);
                }
                else
                {
                    serviceThrottlingBehavior.MaxConcurrentCalls = 400;
                    serviceThrottlingBehavior.MaxConcurrentSessions = 64;
                    serviceThrottlingBehavior.MaxConcurrentInstances = 400 * 64;
                }
                host.Open();
            }
            catch (Exception exception)
            {
                //Console.WriteLine(ex.Message);
                 EventLog.WriteEntry("Ship Cruise Management Service Host", exception.Message, EventLogEntryType.Error);
            }
        }
    }
}
