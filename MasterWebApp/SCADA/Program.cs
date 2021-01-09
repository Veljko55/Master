using System;
using System.Diagnostics;
using System.IO;

namespace SCADA
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSimulator();
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
