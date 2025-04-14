using CompanyApi2.Models;
using CompanyApi2.Infrastructure.DataContext;

namespace CompanyApi2.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        { }
    }
}
