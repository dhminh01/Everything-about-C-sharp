using Domain.Entities;
using Domain.Enums;
using InterfaceAdapters.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters.Repositories
{
    public class PersonRepository(PersonAppDbContext context) : IPersonRepository
    {
        private readonly PersonAppDbContext _context = context;

        public async Task AddAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(Guid id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Person>> FilterAsync(string? name, Gender? gender, string? birthPlace)
        {
            var query = _context.Persons.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p =>
                    p.FirstName.Contains(name) || p.LastName.Contains(name));
            }

            if (gender.HasValue)
            {
                query = query.Where(p => p.Gender == gender);
            }

            if (!string.IsNullOrEmpty(birthPlace))
            {
                query = query.Where(p => p.BirthPlace == birthPlace);
            }

            return await query.ToListAsync();
        }
    }
}