using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskАndProjectManagementSystem.Domain
{
    public class User : IdentityUser
    {
      //  public int Id { get ; set; }    
        public string? Name { get; set; }
        public string? FirstName {  get; set; } 
        public string? LastName { get; set; }    
        public List<Project>? Projects { get; set; }
        public string Password { get; set; }
    }
}