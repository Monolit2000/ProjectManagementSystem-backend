using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskАndProjectManagementSystem.Application.DTO.User;
using TaskАndProjectManagementSystem.Domain;

namespace TaskАndProjectManagementSystem.Application.DTO.Project
{
    public class UpdateProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TaskProd> Tasks { get; set; }
        public UserDTO Manager { get; set; }
    }
}
