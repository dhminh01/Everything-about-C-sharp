using Domain.Entities;
using InterfaceAdapters.DTOs;
using InterfaceAdapters.Repositories;

namespace Application.Services
{
    public class AddPersonService(IPersonRepository personRepository)
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<Guid> AddAsync(CreatePersonDto dto)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                BirthPlace = dto.BirthPlace
            };
            await _personRepository.AddAsync(person);

            return person.Id;
        }
    }
}
