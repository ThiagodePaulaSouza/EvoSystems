using EvoSystems.Models;

namespace EvoSystems.Service.DepartamentService
{
    public interface IDepartament
    {
        Task<ServiceResponse<List<Departament>>> GetDepartaments();
        Task<ServiceResponse<Departament>> CreateDepartament(Departament newDepartament);
        Task<ServiceResponse<Departament>> GetDepartamentById(int id);
        Task<ServiceResponse<Departament>> UpdateDepartament(Departament editedDepartament);
        Task<ServiceResponse<Departament>> DeleteDepartamentById(int id);
        Task<ServiceResponse<Departament>> InactiveDepartament(int id);
    }
}
