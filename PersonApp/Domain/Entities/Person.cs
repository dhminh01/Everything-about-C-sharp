using Domain.Enums;

namespace Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string BirthPlace { get; set; } = string.Empty;
    }
}
