using System.ComponentModel.DataAnnotations;

namespace TaskАndProjectManagementSystem.Application;
public class RegistrationRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    [MinLength(8)]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }   
}
