using CompanyApi2.Models;
using CompanyApi2.Infrastructure.Repositories;

namespace CompanyApi2.Services
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        public ProjectService(IProjectRepository repository) : base(repository) { }
    }
}
