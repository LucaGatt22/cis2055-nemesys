using Microsoft.AspNetCore.Identity;

namespace NEMESYS.Models
{
    public class ApplicationUser: IdentityUser
    {
        [PersonalData]
        public string CustomUsername { get; set; }
    }
}
