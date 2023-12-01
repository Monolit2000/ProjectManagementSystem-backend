using TaskАndProjectManagementSystem.Application.DTO.User;
using TaskАndProjectManagementSystem.Domain;

namespace TaskАndProjectManagementSystem.Application;
public class UpdateTaskDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }
    public Domain.TaskStatus Status { get; set; }
    public Priority Priority { get; set; }
    public List<Comment>? Comments { get; set; }
    public UserDTO? AssignedUser { get; set; }
}
