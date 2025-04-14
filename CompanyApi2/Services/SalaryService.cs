using CompanyApi2.Models;
using CompanyApi2.Infrastructure.Repositories;

namespace CompanyApi2.Services
{
    public class SalaryService : BaseService<Salary>, ISalaryService
    {
        public SalaryService(ISalaryRepository repository) : base(repository) { }
    }
}
