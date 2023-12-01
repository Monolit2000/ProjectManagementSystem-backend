using TaskАndProjectManagementSystem.Application.Contracts.Persistence;
using TaskАndProjectManagementSystem.Domain;
using TaskАndProjectManagementSystem.Persistence.Repositories.Generic;

namespace TaskАndProjectManagementSystem.Persistence;
public class TaskRepository : GenericRepository<TaskProd>, ITaskRepository
{
    private ProgectMengmentApplicationDbContext _dbContext;
    public TaskRepository(ProgectMengmentApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
