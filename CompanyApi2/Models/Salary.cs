namespace CompanyApi2.Models
{
    public class Salary
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public decimal SalaryAmount { get; set; }
    }
}
