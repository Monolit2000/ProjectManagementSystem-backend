using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskАndProjectManagementSystem.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository UserRepository { get; }
        public IProjectsRepository ProjectsRepository { get; }
        public ITaskRepository TaskRepository { get; }
        public Task SaveChaingesAsync();
    }
}
