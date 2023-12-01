using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskАndProjectManagementSystem.Application.DTO.Project;
using TaskАndProjectManagementSystem.Application.DTO.TaskDTO;
using TaskАndProjectManagementSystem.Application.Project;
using TaskАndProjectManagementSystem.Domain;

namespace TaskАndProjectManagementSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskАndProjectManagementSystem.Domain.Project, CreateProjectDTO>().ReverseMap();
            CreateMap<TaskАndProjectManagementSystem.Domain.Project, UpdateProjectDTO>().ReverseMap();
            CreateMap<TaskАndProjectManagementSystem.Domain.TaskProd, CreateTaskDTO>()
               /* .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project))*/.ReverseMap(); 
        }
    }
}
