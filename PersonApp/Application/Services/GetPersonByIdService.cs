using InterfaceAdapters.DTOs;
using InterfaceAdapters.Repositories;

namespace Application.Services
{
    public class GetPersonByIdService(IPersonRepository personRepository)
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<PersonDto?> GetByIdAsync(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person == null)
                return null;

            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                BirthPlace = person.BirthPlace
            };
        }
    }
}