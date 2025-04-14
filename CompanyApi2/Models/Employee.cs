namespace CompanyApi2.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public DateTime JoinedDate { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; } = [];
        public Salary Salary { get; set; } = null!;
    }
}
