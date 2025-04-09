using InterfaceAdapters.DTOs;
using InterfaceAdapters.Repositories;

namespace Application.Services
{
    public class GetAllPersonService(IPersonRepository personRepository)
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<List<PersonDto>> GetAllAsync()
        {
            var person = await _personRepository.GetAllAsync();

            return person.Select(p => new PersonDto
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
