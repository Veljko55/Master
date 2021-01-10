using AssetSCADA.Services.Implementations;
using Common;
using Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AssetSCADA
{
    class Program
    {
        static ServiceHost host = new ServiceHost(typeof(BreakerService));

        static void Main(string[] args)
        {
            StartSimulator();
            BreakerService service = new BreakerService();
            service.RefreshSimulator();
            StartScadaService();
            

            //client side of wcf
            EndpointAddress addr = new EndpointAddress(WCFEndpoints.ScadaEndpoint);
            NetTcpBinding clientBinding = new NetTcpBinding();
            ChannelFactory<IBreakerService> channelFactory = new ChannelFactory<IBreakerService>(clientBinding, addr);
            IBreakerService proxy = channelFactory.CreateChannel();
            proxy.Create("modelcode1");

            Console.ReadKey();
            host.Close();
        }

        static void StartSimulator()
        {
            string workingDirectory = Environment.CurrentDirectory;
            var scadaFolderPath = Directory.GetParent(workingDirectory).Parent.FullName;
            Process.Start($"{scadaFolderPath}/EasyModbus/EasyModbusServerSimulator.exe");
        }

        static void StartScadaService() 
        {

            try 
            {
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IBreakerService), binding, new Uri(WCFEndpoints.ScadaEndpoint));
                host.Open();
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
