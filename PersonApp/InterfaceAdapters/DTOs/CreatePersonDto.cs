using Domain.Enums;

namespace InterfaceAdapters.DTOs
{
    public class CreatePersonDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string BirthPlace { get; set; } = null!;
    }
}
