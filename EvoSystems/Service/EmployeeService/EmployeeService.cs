using EvoSystems.DataContext;
using EvoSystems.Dtos;
using EvoSystems.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoSystems.Service.EmployeeService
{
    public class EmployeeService : IEmployee
    {
        private readonly AppDBContext _context;
        public EmployeeService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Employee>> CreateEmployee(EmployeeRequestDto newEmployee)
        {
            ServiceResponse<Employee> serviceResponse = new ServiceResponse<Employee>();

            try
            {
                var employee = new Employee
                {
                    Name = newEmployee.Name,
                    RG = newEmployee.Rg,
                    DepartamentId = newEmployee.DepartamentId
                };

                if (employee.DepartamentId exist no banco) {

                }
                else
                {
                    vc adiciona um novo no banco? ou devolve erro ao usuario ?
                }


                if (newEmployee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Data is missing.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Add(newEmployee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = newEmployee;
                serviceResponse.Message = "Employee successfully created.";

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Employee>> DeleteEmployeeById(int id)
        {
            ServiceResponse<Employee> serviceResponse = new ServiceResponse<Employee>();

            try
            {
                Employee employee = await _context.Employee.AsNoTracking().SingleAsync(x => x.Id == id);

                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = employee;
                serviceResponse.Message = "Employee successfully deleted.";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                serviceResponse.Data = null;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Employee>> GetEmployeeById(int id)
        {
            ServiceResponse<Employee> serviceResponse = new ServiceResponse<Employee>();

            try
            {
                Employee employee = await _context.Employee.AsNoTracking().SingleAsync(x => x.Id == id);
                serviceResponse.Data = employee;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                serviceResponse.Data = null;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Employee>>> GetEmployees()
        {
            ServiceResponse<List<Employee>> serviceResponse = new ServiceResponse<List<Employee>>();

            try
            {
                serviceResponse.Data = _context.Employee.ToList();

                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "No data was found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Employee>> InactiveEmployee(int id)
        {
            ServiceResponse<Employee> serviceResponse = new ServiceResponse<Employee>();

            try
            {
                Employee employee = await _context.Employee.AsNoTracking().SingleAsync(x => x.Id == id);

                employee.IsActive = false;
                employee.LastUpdatedAt = DateTime.Now.ToLocalTime();

                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = employee;
                serviceResponse.Message = "Employee successfully inactivated.";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                serviceResponse.Data = null;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Employee>> UpdateEmployee(Employee editedEmployee)
        {
            ServiceResponse<Employee> serviceResponse = new ServiceResponse<Employee>();

            try
            {
                Employee employee = await _context.Employee.AsNoTracking().SingleAsync(x => x.Id == editedEmployee.Id);

                employee.LastUpdatedAt = DateTime.Now.ToLocalTime();

                _context.Employee.Update(editedEmployee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = editedEmployee;
                serviceResponse.Message = "Employee successfully updated.";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                serviceResponse.Data = null;
            }

            return serviceResponse;
        }
    }
}
