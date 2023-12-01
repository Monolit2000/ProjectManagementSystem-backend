using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskАndProjectManagementSystem.Application.Model.Identity;

namespace TaskАndProjectManagementSystem.Application.Contracts.Identity
{
    public interface IAuthService
    {
        public Task<AuthResponce> Login(AuthRequest request);
        public Task<RegistrationResponce> Registration(RegistrationRequest request);
    }
}
