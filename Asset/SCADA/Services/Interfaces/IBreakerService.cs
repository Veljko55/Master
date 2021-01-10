using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA.Services.Interfaces
{
    public interface IBreakerService
    {
        public void SetValue(bool value, string modelCode);
        public bool GetValue(string modelCode);
        public bool ModelCodeExist(string modelCode);
        public void Create(string modelCode);
        public void Delete(string modelCode);
        public void InsertMany(List<string> modelCodes);
        public void RefreshSimulator();
    }
}
