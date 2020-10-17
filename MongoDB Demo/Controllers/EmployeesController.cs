using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_Demo.Data.Services.Interfaces;
using MongoDB_Demo.Models;

namespace MongoDB_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService employeeService)
        {
            _service = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get();

            return Ok(result);
        }

        [HttpGet("{id}", Name = nameof(Get))]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _service.Get(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            await _service.Create(employee);

            return CreatedAtRoute(nameof(Get), new { id = employee.Id }, employee);
        }
    }
}