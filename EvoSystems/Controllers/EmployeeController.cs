using EvoSystems.Dtos;
using EvoSystems.Models;
using EvoSystems.Service.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;
        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Employee>>>> GetEmployees()
        {
            return Ok(await _employeeService.GetEmployees());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Employee>>> CreateEmployee(EmployeeRequestDto newEmployee)
        {
            var result = await _employeeService.CreateEmployee(newEmployee);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Employee>>> GetEmployeeById(int id)
        {
            ServiceResponse<Employee> serviceResponse = await _employeeService.GetEmployeeById(id);

            return Ok(serviceResponse);
        }

        [HttpPut("inactiveEmployee")]
        public async Task<ActionResult<ServiceResponse<Employee>>> InactiveEmployee(int id)
        {
            ServiceResponse<Employee> serviceResponse = await _employeeService.InactiveEmployee(id);

            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Departament>>> UpdateEmployee(Employee editedEmployee)
        {
            ServiceResponse<Employee> serviceResponse = await _employeeService.UpdateEmployee(editedEmployee);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<Employee>>> DeleteEmployeeById(int id)
        {
            ServiceResponse<Employee> serviceResponse = await _employeeService.DeleteEmployeeById(id);

            return Ok(serviceResponse);
        }
    }
}
