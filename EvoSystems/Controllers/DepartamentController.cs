using EvoSystems.Models;
using EvoSystems.Service.DepartamentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly IDepartament _departamentService;
        public DepartamentController(IDepartament departamentService)
        {
            _departamentService = departamentService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Departament>>>> GetDepartaments()
        {
            return Ok(await _departamentService.GetDepartaments());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Departament>>> CreateDepartament(Departament newDepartament)
        {
            return Ok(await _departamentService.CreateDepartament(newDepartament));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Departament>>> GetDepartamentById(int id)
        {
            ServiceResponse<Departament> serviceResponse = await _departamentService.GetDepartamentById(id);

            return Ok(serviceResponse);
        }

        [HttpPut("inactiveDepartament")]
        public async Task<ActionResult<ServiceResponse<Departament>>> InactiveDepartament(int id)
        {
            ServiceResponse<Departament> serviceResponse = await _departamentService.InactiveDepartament(id);

            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Departament>>> UpdateDepartament(Departament editedDepartament)
        {
            ServiceResponse<Departament> serviceResponse = await _departamentService.UpdateDepartament(editedDepartament);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<Departament>>> DeleteDepartamentById(int id)
        {
            ServiceResponse<Departament> serviceResponse = await _departamentService.DeleteDepartamentById(id);

            return Ok(serviceResponse);
        }
    }
}
