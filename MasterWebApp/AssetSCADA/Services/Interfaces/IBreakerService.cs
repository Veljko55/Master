using System;
using System.Collections.Generic;
using System.Text;

namespace AssetSCADA.Services.Interfaces
{
    public interface IBreakerService
    {
         void SetValue(bool value, string modelCode);
         bool GetValue(string modelCode);
         bool ModelCodeExist(string modelCode);
         void Create(string modelCode);
         void Delete(string modelCode);
         void InsertMany(List<string> modelCodes);
         void RefreshSimulator();
    }
}
