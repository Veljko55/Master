using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Common.Services.Interfaces
{
    [ServiceContract]
    public interface IBreakerService
    {
        [OperationContract]
        void SetValue(bool value, string modelCode);
        [OperationContract]
        bool GetValue(string modelCode);
        [OperationContract]
        bool ModelCodeExist(string modelCode);
        [OperationContract]
        void Create(string modelCode);
        [OperationContract]
        void Delete(string modelCode);
        [OperationContract]
        void InsertMany(List<string> modelCodes);
        [OperationContract]
        void RefreshSimulator();
    }
}
