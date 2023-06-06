using Microsoft.AspNetCore.Identity;

namespace HFC.Domain
{
    public class AppUser : IdentityUser
    {
        public ICollection<Task> Tasks { get; set; }
    }
}