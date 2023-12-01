using TaskАndProjectManagementSystem.Application.Contracts.Persistence;
using TaskАndProjectManagementSystem.Domain;
using TaskАndProjectManagementSystem.Persistence.Repositories.Generic;

namespace TaskАndProjectManagementSystem.Persistence;
public class ProjectsRepository : GenericRepository<Project>, IProjectsRepository
{
        private ProgectMengmentApplicationDbContext _dbContext;
    public ProjectsRepository(ProgectMengmentApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }       
}
