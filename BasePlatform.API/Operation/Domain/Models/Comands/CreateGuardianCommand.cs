using System.ComponentModel.DataAnnotations;

namespace BasePlatform.API.Operation.Domain.Models.Comands;

public record CreateGuardianCommand()
{
    [MaxLength(30)]
    public string Username { get; set; }
    public string Email { get; set; }
    
    [MaxLength(60)]
    public string FirstName { get; set; }
    public string LastName { get; set; }
}