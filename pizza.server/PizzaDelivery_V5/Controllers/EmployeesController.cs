using Microsoft.AspNetCore.Mvc;
using PizzaDelivery_V5.Entities.Entities;
using PizzaDelivery_V5.Repositories.Interfaces;

namespace PizzaDelivery_V5.Controllers
{
    [ApiController]
    [Route("api/DAL/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> EmployeeList()
        {
            var employee = await _employeeRepository.Get();
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpGet("12345")]
        public async Task<IActionResult> EmployeeGet(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            return Ok(employee);
        }

        [HttpGet("name")]
        public async Task<IActionResult> EmployeeGet(string name)
        {
            var employee = await _employeeRepository.GetByNameEntity(name);
            return Ok(employee);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var result = await _employeeRepository.Add(employee);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var result = await _employeeRepository.Update(employee);
            return Ok(result);
        }

        [HttpDelete("delete/12345")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeRepository.Delete(id);
            return Ok(result);
        }
    }
}
