using Microsoft.AspNetCore.Mvc;
using CompanyApi2.Models;
using CompanyApi2.Services;
using CompanyApi2.Infrastructure.Dtos;

namespace CompanyApi2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _employeeService.GetByIdAsync(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            await _employeeService.AddAsync(employee);

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            await _employeeService.UpdateAsync(employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("with-department")]
        public async Task<IActionResult> GetWithDepartment()
        {
            var result = await _employeeService.GetEmployeesWithDepartmentAsync();

            return Ok(result);
        }

        [HttpGet("with-projects")]
        public async Task<IActionResult> GetWithProjects()
        {
            var result = await _employeeService.GetEmployeesWithProjectsAsync();

            return Ok(result);
        }

        [HttpGet("high-salary-recent")]
        public async Task<IActionResult> GetHighSalaryRecent()
        {
            var result = await _employeeService.GetHighSalaryRecentEmployeesAsync();

            return Ok(result);
        }

        [HttpGet("with-department-raw")]
        public async Task<IActionResult> GetWithDepartmentRaw()
        {
            var result = await _employeeService.GetEmployeesWithDepartmentRawSqlAsync();

            return Ok(result);
        }

        [HttpGet("with-projects-raw")]
        public async Task<IActionResult> GetWithProjectsRaw()
        {
            var result = await _employeeService.GetEmployeesWithProjectsRawSqlAsync();

            return Ok(result);
        }

        [HttpGet("high-salary-recent-raw")]
        public async Task<IActionResult> GetHighSalaryRecentRaw()
        {
            var result = await _employeeService.GetHighSalaryRecentEmployeesRawSqlAsync();

            return Ok(result);
        }
    }
}
