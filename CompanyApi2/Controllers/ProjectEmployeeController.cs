using CompanyApi2.Models;
using CompanyApi2.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeeController : ControllerBase
    {
        private readonly IProjectEmployeeService _service;

        public ProjectEmployeeController(IProjectEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{projectId}/{employeeId}")]
        public async Task<IActionResult> GetById(Guid projectId, Guid employeeId)
        {
            var result = await _service.GetByIdAsync(projectId, employeeId);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectEmployee pe)
        {
            await _service.AddAsync(pe);

            return Ok();
        }

        [HttpPut("{projectId}/{employeeId}")]
        public async Task<IActionResult> Update(Guid projectId, Guid employeeId, [FromBody] ProjectEmployee pe)
        {
            if (projectId != pe.ProjectId || employeeId != pe.EmployeeId)
                return BadRequest("ProjectId and EmployeeId must match.");

            await _service.UpdateAsync(pe);

            return NoContent();
        }

        [HttpDelete("{projectId}/{employeeId}")]
        public async Task<IActionResult> Delete(Guid projectId, Guid employeeId)
        {
            await _service.DeleteAsync(projectId, employeeId);

            return NoContent();
        }
    }
}
