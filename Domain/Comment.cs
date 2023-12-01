namespace TaskАndProjectManagementSystem.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
    }
}