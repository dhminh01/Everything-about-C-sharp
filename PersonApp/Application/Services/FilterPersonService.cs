using Domain.Enums;
using InterfaceAdapters.DTOs;
using InterfaceAdapters.Repositories;

namespace Application.Services
{
    public class FilterPersonService(IPersonRepository personRepository)
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<List<PersonDto>> FilterAsync(string? name, Gender? gender, string? birthPlace)
        {
            var people = await _personRepository.FilterAsync(name, gender, birthPlace);

            return people.Select(p => new PersonDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                BirthPlace = p.BirthPlace
            }).ToList();
        }
    }
}
