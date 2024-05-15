using Microsoft.AspNetCore.Identity;

namespace Bloggy.Models
{
    public class ApplicationUser: IdentityUser
    {
        [PersonalData]
        public string Username { get; set; }
    }
}
