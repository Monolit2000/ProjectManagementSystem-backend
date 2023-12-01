using TaskАndProjectManagementSystem.Application.DTO.User;
using TaskАndProjectManagementSystem.Domain;
using TaskStatus = TaskАndProjectManagementSystem.Domain.TaskStatus;

namespace TaskАndProjectManagementSystem.Application.DTO.TaskDTO;
public class CreateTaskDTO
{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskStatus Status { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedUserId { get; set; }
}
