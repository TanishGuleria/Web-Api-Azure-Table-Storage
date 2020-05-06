using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace WebApiWithAzureTableStorage.Model
{
    public class EmployeeEntity : TableEntity
    {
        public EmployeeEntity()
        {

        }
        public EmployeeEntity(Employee e)
        {
            this.PartitionKey = e.JobTitle;
                this.RowKey = e.EmpID;
        }
    }
}
