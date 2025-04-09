using Application.Services;
using Domain.Enums;
using InterfaceAdapters.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FrameworksAndDrivers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController(
        AddPersonService addPersonService,
        UpdatePersonService updatePersonService,
        DeletePersonService deletePersonService,
        FilterPersonService filterPersonService,
        GetAllPersonService getAllPersonService,
        GetPersonByIdService getPersonByIdService) : ControllerBase
    {
        private readonly AddPersonService _addPersonService = addPersonService;
        private readonly UpdatePersonService _updatePersonService = updatePersonService;
        private readonly DeletePersonService _deletePersonService = deletePersonService;
        private readonly FilterPersonService _filterPersonService = filterPersonService;
        private readonly GetAllPersonService _getAllPersonService = getAllPersonService;
        private readonly GetPersonByIdService _getPersonByIdService = getPersonByIdService;

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var person = await _getAllPersonService.GetAllAsync();
            return Ok(person);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter(
            [FromQuery] string? name,
            [FromQuery] Gender? gender,
            [FromQuery] string? birthPlace)
        {
            var person = await _filterPersonService.FilterAsync(name, gender, birthPlace);

            return Ok(person);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var person = await _getPersonByIdService.GetByIdAsync(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] CreatePersonDto dto)
        {
            var id = await _addPersonService.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePersonDto dto)
        {
            var success = await _updatePersonService.UpdateAsync(id, dto);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _deletePersonService.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }


    }
}
