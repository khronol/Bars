using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Test
{
    
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        void NewContract(TestDBEntities db, Contracts tmp);
        [OperationContract]
        void DeleteContract(TestDBEntities db, Contracts tmp);
    }
}
