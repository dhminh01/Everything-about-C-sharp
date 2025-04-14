using CompanyApi2.Models;
using CompanyApi2.Infrastructure.DataContext;

namespace CompanyApi2.Infrastructure.Repositories
{
    public class SalaryRepository : BaseRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(AppDbContext context) : base(context)
        { }
    }
}
