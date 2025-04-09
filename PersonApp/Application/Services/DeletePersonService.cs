using InterfaceAdapters.Repositories;

namespace Application.Services
{
    public class DeletePersonService(IPersonRepository personRepository)
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<bool> DeleteAsync(Guid id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null) return false;

            await _personRepository.DeleteAsync(id);

            return true;
        }
    }
}
