using Microsoft.AspNetCore.Identity;

namespace Personal_Blog.Models.Schema
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
