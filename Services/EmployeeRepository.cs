using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithAzureTableStorage.Model;
using Microsoft.Azure.Cosmos.Table;

namespace WebApiWithAzureTableStorage.Services
{
    public class EmployeeRepository : IEmployee
    {
        static CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=mysgstorage;AccountKey=+jGZPwhioMYOBxx3lHjrsF7T16J+8Dw2LqReb2UPutSO4IY/Uofh13yeAmUA70b3RoKnGReN7AxfV8T8ON70Zw==;EndpointSuffix=core.windows.net");
        static CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        static CloudTable employees = tableClient.GetTableReference("Employee");

        public EmployeeRepository()
        {
        }
        public IEnumerable<EmployeeEntity> GetDataFromTable()
        {
         
            TableQuery<EmployeeEntity> query = new TableQuery<EmployeeEntity>();
            var q = employees.ExecuteQuery(query);

            return q;
        }

        public void InsertToAzureTable(Employee e)
        {
            EmployeeEntity employee1 = new EmployeeEntity(e);
            employees.CreateIfNotExistsAsync();


            TableOperation inserttop = TableOperation.Insert(employee1);
            employees.ExecuteAsync(inserttop).GetAwaiter().GetResult();
        }
    }
}
