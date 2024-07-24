using Microsoft.AspNetCore.Identity;

namespace TaskItService.Models
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }
    }
}
