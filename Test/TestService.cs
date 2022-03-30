using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Test
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "TestService" в коде и файле конфигурации.
    public class TestService : ITestService
    {
        public void DeleteContract(TestDBEntities db,Contracts tmp)
        {
            db.Contracts.Remove(tmp);
            db.SaveChanges();
        }

        public void NewContract(TestDBEntities db, Contracts tmp)
        {
            db.Contracts.Add(tmp);
            db.SaveChanges();
        }
    }
}
