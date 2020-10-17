using MongoDB.Driver;
using MongoDB_Demo.Data.Services.Interfaces;
using MongoDB_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_Demo.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);
        }

        public async Task Create(Employee employee)
        {
            await _employees
                .InsertOneAsync(employee);
        }

        public async Task Delete(string id)
        {
            await _employees
                .DeleteOneAsync(e => e.Id == id);   
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = await _employees
                .Find(e => true)
                .ToListAsync();

            return employees;               
        }

        public async Task<Employee> Get(string id)
        {
            var employee = await _employees
                .Find(e => e.Id == id)
                .FirstOrDefaultAsync();

            return employee;
        }
    }
}
