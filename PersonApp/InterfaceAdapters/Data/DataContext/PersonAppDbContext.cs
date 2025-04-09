using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace InterfaceAdapters.Data.DataContext
{
    public class PersonAppDbContext(DbContextOptions<PersonAppDbContext> options) : DbContext(options)
    {
        public DbSet<Person> Persons { get; set; } 
    }
}
