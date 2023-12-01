using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskАndProjectManagementSystem.Application.DTO.User;
using TaskАndProjectManagementSystem.Domain;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace TaskАndProjectManagementSystem.Application.TaskDTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskStatus Status { get; set; }
        public Priority Priority { get; set; } 
        public List<Comment>? Comments { get; set; }
        public UserDTO? AssignedUser { get; set; }
    }
}
