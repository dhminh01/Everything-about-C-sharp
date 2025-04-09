using Domain.Enums;

namespace InterfaceAdapters.DTOs
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string BirthPlace { get; set; } = null!;
    }
}
