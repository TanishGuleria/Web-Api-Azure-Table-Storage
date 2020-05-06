using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithAzureTableStorage.Model;

namespace WebApiWithAzureTableStorage.Services
{

    public interface IEmployee
    {
       IEnumerable<EmployeeEntity> GetDataFromTable();

        void InsertToAzureTable(Employee e);
        
    }
}
