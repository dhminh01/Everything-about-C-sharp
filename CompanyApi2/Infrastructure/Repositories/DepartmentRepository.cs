using CompanyApi2.Infrastructure.DataContext;
using CompanyApi2.Models;

namespace CompanyApi2.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        { }
    }
}