using System;
using System.Diagnostics;
using System.IO;
using SCADA.Services.Implementations;

namespace SCADA
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSimulator(); 
            BreakerService service = new BreakerService();
            service.RefreshSimulator();
            Console.ReadKey();
        }

        static void StartSimulator() 
        {
            string workingDirectory = Environment.CurrentDirectory;
            var scadaFolderPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Process.Start($"{scadaFolderPath}/EasyModbus/EasyModbusServerSimulator.exe");
        }
    }
}
