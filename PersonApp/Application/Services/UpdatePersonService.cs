using InterfaceAdapters.DTOs;
using InterfaceAdapters.Repositories;

namespace Application.Services
{
    public class UpdatePersonService (IPersonRepository personRepository)
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<bool> UpdateAsync(Guid id, UpdatePersonDto dto)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null) return false;

            person.FirstName = dto.FirstName;
            person.LastName = dto.LastName;
            person.DateOfBirth = dto.DateOfBirth;
            person.Gender = dto.Gender;
            person.BirthPlace = dto.BirthPlace;

            await _personRepository.UpdateAsync(person);
            return true;
        }
    }
}
