using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Serialization;
using ShipCruiseManagementSystem.Services.Inter;

namespace ShipCruiseManagementSystem.Service.Broker
{
    public class UserBrokerService : IUserBrokerService, IDisposable
    {
        public IUserService Proxy { get; set; }

        private ChannelFactory<IUserService> channelFactory;

        public UserBrokerService(string host, int port)
        {
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
            binding.TransferMode = TransferMode.Buffered;
            binding.SendTimeout = binding.ReceiveTimeout = new TimeSpan(0, 2, 0);
            EndpointAddress endpointAddress = new EndpointAddress(string.Format("net.tcp://{0}:{1}", host, port));
            channelFactory = new ChannelFactory<IUserService>(binding, endpointAddress);

            foreach (var operation in channelFactory.Endpoint.Contract.Operations)
            {
                var behavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (behavior != null)
                {
                    behavior.MaxItemsInObjectGraph = 2147483647;
                }
            }

            Proxy = channelFactory.CreateChannel();
        }


        public void Dispose()
        {
            if (channelFactory.State == CommunicationState.Opened)
                channelFactory.Close();

        }


    }

}
