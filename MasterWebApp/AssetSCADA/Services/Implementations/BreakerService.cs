using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AssetSCADA.Entities;
using EasyModbus;
using AssetSCADA.Services.Interfaces;

namespace AssetSCADA.Services.Implementations
{
    public class BreakerService : IBreakerService
    {
        public void Create(string modelCode)
        {
            using (var context = new ScadaDB.ScadaContext())
            {
                if (!this.ModelCodeExist(modelCode)) 
                {
                    int simulatorAddress = context.Breakers.Count();
                    context.Breakers.Add(new ScadaBreaker()
                    {
                        Value = true,
                        ModelCode = modelCode,
                        IsDeleted = false,
                        SimulatorAddress = simulatorAddress
                    });
                    context.SaveChanges();
                    this.RefreshSimulator();

                }
            }
        }

        public void Delete(string modelCode)
        {
            using (var context = new ScadaDB.ScadaContext())
            {
                var breaker = context.Breakers.FirstOrDefault(x => x.ModelCode == modelCode);
                breaker.IsDeleted = true;
                context.SaveChanges();
            }
            this.RefreshSimulator();

        }

        public bool GetValue(string modelCode)
        {
            using (var context = new ScadaDB.ScadaContext())
            {
                return context.Breakers.FirstOrDefault(x => x.ModelCode == modelCode).Value;
            }
        }

        public void InsertMany(List<string> modelCodes)
        {
            using (var context = new ScadaDB.ScadaContext())
            {
                foreach (string modelCode in modelCodes)
                {
                    if (!this.ModelCodeExist(modelCode))
                    {
                        int simulatorAddress = context.Breakers.Count();
                        context.Breakers.Add(new ScadaBreaker()
                        {
                            Value = false,
                            ModelCode = modelCode,
                            IsDeleted = false,
                            SimulatorAddress = ++simulatorAddress
                        });
                    }
                }

                context.SaveChanges();
            }

            this.RefreshSimulator();
        }

        public bool ModelCodeExist(string modelCode)
        {

            using (var context = new ScadaDB.ScadaContext())
            {
                return context.Breakers.FirstOrDefault(x => x.ModelCode == modelCode) != null;
            }
        }

        public void SetValue(bool value, string modelCode)
        {
            using (var context = new ScadaDB.ScadaContext())
            {
                ScadaBreaker breaker = context.Breakers.FirstOrDefault(x => x.ModelCode == modelCode);
                breaker.Value = value;
                context.SaveChanges();
            }
            this.RefreshSimulator();
        }

        public void RefreshSimulator() 
        {
            List<ScadaBreaker> breakers = new List<ScadaBreaker>();
            using (var context = new ScadaDB.ScadaContext())
            {
                breakers = context.Breakers.Where(x => !x.IsDeleted).ToList();
            }


            ModbusClient modbusClient = new ModbusClient("127.0.0.1", 502);    //Ip-Address and Port of Modbus-TCP-Server
            //modbusClient.UnitIdentifier = 1; Not necessary since default slaveID = 1;
            //modbusClient.Baudrate = 9600;	// Not necessary since default baudrate = 9600
            //modbusClient.Parity = System.IO.Ports.Parity.None;
           // modbusClient.StopBits = System.IO.Ports.StopBits.Two;
            //modbusClient.Port = 502;
            modbusClient.Connect();

            foreach (var breaker in breakers) 
            {
                modbusClient.WriteSingleCoil(breaker.SimulatorAddress, breaker.Value);
            }
        }

        
    }
}
