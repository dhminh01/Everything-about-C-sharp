namespace CompanyApi2.Infrastructure.Dtos
{
    public class HighSalaryRecentEmployeeDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
