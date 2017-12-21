using FTN.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Client.Connection
{
    public class Connection
    {
        private static Connection instance;

        public INetworkModelGDAContract Proxy { get; set; }

        private Connection()
        {
            var binding = new NetTcpBinding();
            Proxy = new ChannelFactory<INetworkModelGDAContract>("*").CreateChannel();
        }
        public static Connection Instance()
        {
            if(instance == null)
            {
                instance = new Connection();
            }
            return instance;
        }
    }
}
