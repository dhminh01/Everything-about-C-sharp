using Domain.Entities;
using Domain.Enums;

namespace InterfaceAdapters.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(Guid id);
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Guid id);
        Task<List<Person>> FilterAsync(string? name, Gender? gender, string? birthPlace);
    }
}
