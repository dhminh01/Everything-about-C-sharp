using Domain.Entities;
using Domain.Enums;
using InterfaceAdapters.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters.Data.Persistence.Seeds
{
    public static class PersonAppSeeder
    {
        public static async Task SeedAsync(PersonAppDbContext context)
        {
            if (!context.Persons.Any())
            {
                var people = new List<Person>
                {
                    new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "John",
                        LastName = "Doe",
                        DateOfBirth = new DateTime(1995, 5, 15),
                        Gender = Gender.Male,
                        BirthPlace = "New York"
                    },
                    new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Jane",
                        LastName = "Smith",
                        DateOfBirth = new DateTime(1990, 8, 20),
                        Gender = Gender.Female,
                        BirthPlace = "London"
                    },
                    new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Alex",
                        LastName = "Nguyen",
                        DateOfBirth = new DateTime(2000, 12, 1),
                        Gender = Gender.Other,
                        BirthPlace = "Hanoi"
                    }
                };

                context.Persons.AddRange(people);
                await context.SaveChangesAsync();
            }
        }
    }
}
