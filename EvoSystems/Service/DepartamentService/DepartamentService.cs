using EvoSystems.DataContext;
using EvoSystems.Models;
using EvoSystems.Repository;
using Microsoft.EntityFrameworkCore;

namespace EvoSystems.Service.DepartamentService
{
    public class DepartamentService : IDepartament
    {
        private readonly AppDBContext _context;
        private readonly EmployeeRepository employeeRepository;
        public DepartamentService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<Departament>> CreateDepartament(Departament newDepartament)
        {
            ServiceResponse<Departament> serviceResponse = new ServiceResponse<Departament>();

            try
            {
                if (newDepartament == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Data is missing.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Add(newDepartament);
                await _context.SaveChangesAsync();

                serviceResponse.Data = newDepartament;
                serviceResponse.Message = "Departament created.";

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Departament>> DeleteDepartamentById(int id)
        {
            ServiceResponse<Departament> serviceResponse = new ServiceResponse<Departament>();

            try
            {
                Departament departament = await _context.Departament.AsNoTracking().SingleAsync(x => x.Id == id);

                _context.Departament.Remove(departament);
                await _context.SaveChangesAsync();

                serviceResponse.Data = departament;
                serviceResponse.Message = "Department successfully deleted.";

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                serviceResponse.Data = null;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Departament>>> GetDepartaments()
        {
            ServiceResponse<List<Departament>> serviceResponse = new ServiceResponse<List<Departament>>();

            try
            {
                serviceResponse.Data = _context.Departament.ToList();

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

        public async Task<ServiceResponse<Departament>> GetDepartamentById(int id)
        {
            ServiceResponse<Departament> serviceResponse = new ServiceResponse<Departament>();

            try
            {
                Departament departament = await _context.Departament.AsNoTracking().SingleAsync(x => x.Id == id);
                serviceResponse.Data = departament;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                serviceResponse.Data = null;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Departament>> InactiveDepartament(int id)
        {
            ServiceResponse<Departament> serviceResponse = new ServiceResponse<Departament>();

            try
            {
                Departament departament = await _context.Departament.AsNoTracking().SingleAsync(x => x.Id == id);

                departament.IsActive = false;
                departament.LastUpdatedAt = DateTime.Now.ToLocalTime();

                _context.Departament.Update(departament);
                await _context.SaveChangesAsync();

                serviceResponse.Data = departament;
                serviceResponse.Message = "Department successfully inactivated.";


            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                serviceResponse.Data = null;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Departament>> UpdateDepartament(Departament editedDepartament)
        {
            ServiceResponse<Departament> serviceResponse = new ServiceResponse<Departament>();

            try
            {
                Departament departament = await _context.Departament.AsNoTracking().SingleAsync(x => x.Id == editedDepartament.Id);

                departament.LastUpdatedAt = DateTime.Now.ToLocalTime();

                _context.Departament.Update(editedDepartament);
                await _context.SaveChangesAsync();

                serviceResponse.Data = editedDepartament;
                serviceResponse.Message = "Department successfully updated.";


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
