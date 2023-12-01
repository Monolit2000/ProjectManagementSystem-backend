using System.Xml.Linq;

namespace TaskАndProjectManagementSystem.Domain
{ 
        public class TaskProd

        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public DateTime Deadline { get; set; }
            public TaskStatus Status { get; set; }
            public Priority Priority { get; set; }
            public Project Project { get; set; }    
            public List<Comment>? Comments { get; set; }
            public User? AssignedUser { get; set; }
        }
        public enum TaskStatus
        {
            Open,
            InProgress,
            Completed
        }

        public enum Priority
        {
            Low,
            Medium,
            High
        }
}