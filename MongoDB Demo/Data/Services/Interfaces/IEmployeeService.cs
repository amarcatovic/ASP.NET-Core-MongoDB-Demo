using MongoDB_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_Demo.Data.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(string id);
        Task Create(Employee employee);
        Task Delete(string id);
    }
}
