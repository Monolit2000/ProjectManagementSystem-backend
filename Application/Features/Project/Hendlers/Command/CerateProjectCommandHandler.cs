using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskАndProjectManagementSystem.Application.Constants;
using TaskАndProjectManagementSystem.Application.Contracts.Persistence;
//using TaskАndProjectManagementSystem.Application.DTO.Project;
using TaskАndProjectManagementSystem.Application.Features.Project.Request.Command;
using TaskАndProjectManagementSystem.Application.Project;

namespace TaskАndProjectManagementSystem.Application.Features.Project.Hendlers.Command
{
    public class CerateProjectCommandHandler : IRequestHandler<CerateProjectCommand, BaseCommandResponse>
    {
        private readonly UserManager<TaskАndProjectManagementSystem.Domain.User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProjectsRepository _projectsRepository;
        private readonly IValidator<CreateProjectDTO> _validator; //To test
        private readonly IMapper _mapper;

        public CerateProjectCommandHandler(IHttpContextAccessor httpContextAccessor , UserManager<TaskАndProjectManagementSystem.Domain.User> userManager, IProjectsRepository projectsRepository, IMapper autoMapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _projectsRepository = projectsRepository;
            _userManager = userManager;
            _mapper = autoMapper;
        }

        public async Task<BaseCommandResponse> Handle(CerateProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProjectDTOValidator();
            var validationResult = await validator.ValidateAsync(request.createProjectDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
                    q => q.Type == JwtRegisteredClaimNames.Email)?.Value;

            var user = _userManager.FindByEmail(userName);  
            if(user is null)
            {
                response.Success = false;
                response.Message = "User email not found";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var newProject = new Domain.Project()
            {
                Id = 1,
                Name = request.createProjectDTO.Name,
                Description = request.createProjectDTO.Description,
                StartDate = DateTime.Now,
                Manager = user

            };

            var proj = _projectsRepository.Add(newProject);

            if (proj != null)
            {

                //var responce = new BaseCommandResponse()
                //{
                //    id = proj.Id,
                //    Success = true,
                //    Message = ""
                //};
                return response;
            }

            else 
                throw new Exception();
        }
    }
}
