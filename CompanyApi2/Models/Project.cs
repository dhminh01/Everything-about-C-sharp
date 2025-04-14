namespace CompanyApi2.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; } = [];
    }
}
