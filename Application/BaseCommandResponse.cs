namespace TaskАndProjectManagementSystem.Application
{
    public class BaseCommandResponse
    {
        public int id { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string> Errors { get; set; }
    }
}