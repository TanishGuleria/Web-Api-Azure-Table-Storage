using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;

using WebApiWithAzureTableStorage.Model;
using WebApiWithAzureTableStorage.Services;
namespace WebApiWithAzureTableStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee employeeRepository = new EmployeeRepository();

     
        [HttpGet]
        public  IEnumerable<EmployeeEntity> Get()
        {


            return employeeRepository.GetDataFromTable();


        }

        [HttpPost]
        public void Post([FromBody] Employee e1 )
        {

            employeeRepository.InsertToAzureTable(e1);


        }


    }
}


