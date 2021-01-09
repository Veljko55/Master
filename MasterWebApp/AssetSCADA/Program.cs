using AssetSCADA.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            Console.ReadKey();
        }

        static void StartSimulator()
        {
            string workingDirectory = Environment.CurrentDirectory;
            var scadaFolderPath = Directory.GetParent(workingDirectory).Parent.FullName;
            Process.Start($"{scadaFolderPath}/EasyModbus/EasyModbusServerSimulator.exe");
        }
    }
}
