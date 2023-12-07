using EvoSystems.Dtos;
using EvoSystems.Models;

namespace EvoSystems.Service.EmployeeService
{
    public interface IEmployee
    {
        Task<ServiceResponse<List<Employee>>> GetEmployees();
        Task<ServiceResponse<Employee>> CreateEmployee(EmployeeRequestDto newEmployee);
        Task<ServiceResponse<Employee>> GetEmployeeById(int id);
        Task<ServiceResponse<Employee>> UpdateEmployee(Employee editedEmployee);
        Task<ServiceResponse<Employee>> DeleteEmployeeById(int id);
        Task<ServiceResponse<Employee>> InactiveEmployee(int id);
    }
}
