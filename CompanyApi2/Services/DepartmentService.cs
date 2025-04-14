using CompanyApi2.Infrastructure.Repositories;
using CompanyApi2.Models;

namespace CompanyApi2.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        public DepartmentService(IDepartmentRepository repository) : base(repository)
        { }
    }
}
