using TaskАndProjectManagementSystem.Application.Contracts.Persistence;
using TaskАndProjectManagementSystem.Persistence.Repositories;

namespace TaskАndProjectManagementSystem.Persistence;
public class UnitOfWork : IUnitOfWork
{
    
    public IUserRepository _userRepository;
    public ITaskRepository _taskRepository;
    public IProjectsRepository _projectsRepository;
    private readonly ProgectMengmentApplicationDbContext _context;
    public UnitOfWork(ProgectMengmentApplicationDbContext DBcontext)
    {
        _context = DBcontext;
    }

    public IUserRepository UserRepository =>
        _userRepository ??= new UserRepository(_context);

    public ITaskRepository TaskRepository =>
        _taskRepository ??= new TaskRepository(_context);

    public IProjectsRepository ProjectsRepository =>
        _projectsRepository ??= new ProjectsRepository(_context);

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task SaveChaingesAsync()
    {
       await _context.SaveChangesAsync();   
    }
}
