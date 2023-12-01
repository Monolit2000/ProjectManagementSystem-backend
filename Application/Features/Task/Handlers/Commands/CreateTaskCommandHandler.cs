using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using TaskАndProjectManagementSystem.Application.Contracts.Persistence;
using TaskАndProjectManagementSystem.Application.DTO.TaskDTO;
using TaskАndProjectManagementSystem.Domain;

namespace TaskАndProjectManagementSystem.Application;
public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, BaseCommandResponse>
{
    public ITaskRepository _taskRepository;
    public IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private IHttpContextAccessor _httpContextAccessor;
    private UserManager<Domain.User> _userManager;

    public CreateTaskCommandHandler(IHttpContextAccessor httpContextAccessor, UserManager<Domain.User> userManager, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager= userManager;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskExist = await _taskRepository.Exists(request.createTask.Id);
         
        if (taskExist)
            throw new Exception("id dublicate ");

        var project = await _unitOfWork.ProjectsRepository.Get(request.createTask.ProjectId);

        if (project is null)
            throw new Exception("project not found");

        var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
                   q => q.Type == JwtRegisteredClaimNames.Email)?.Value;

        var user = _userManager.FindByEmail(userName);

        if (user is null)
            throw new Exception("User not found");

         var newTask = _mapper.Map<TaskProd>(request.createTask);

         newTask.Project = project;
         newTask.AssignedUser = user;



        var baseComandResponce = new BaseCommandResponse()
        {
            id = newTask.Id,
            Success = true,
            Message = ""
        };

        return baseComandResponce;  
    }
}
