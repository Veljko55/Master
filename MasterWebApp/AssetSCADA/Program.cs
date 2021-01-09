using AssetSCADA.Services.Implementations;
using AssetSCADA.Services.Interfaces;
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

        static void Main(string[] args)
        {
            StartSimulator();
            BreakerService service = new BreakerService();
            service.RefreshSimulator();
            service.Create("test1") ;

            Uri baseAddress = new Uri("localhost:8080/scada");

            ServiceHost host = new ServiceHost(typeof(BreakerService));
            NetTcpBinding binding = new NetTcpBinding();
            host.AddServiceEndpoint(typeof(IBreakerService), binding, new Uri("net.tcp://localhost:5000/scada"));
            host.Open();

            Console.ReadKey();
            host.Close();
        }

        static void StartSimulator()
        {
            string workingDirectory = Environment.CurrentDirectory;
            var scadaFolderPath = Directory.GetParent(workingDirectory).Parent.FullName;
            Process.Start($"{scadaFolderPath}/EasyModbus/EasyModbusServerSimulator.exe");
        }
    }
}
