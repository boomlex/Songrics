using Microsoft.AspNetCore.Identity;

namespace Songrics.Data.Models
{
    // Add profile data for application users by adding properties to the SongricsUser class
    public class SongricsUser : IdentityUser
    {
        public string Nickname { get; set; }
    }
}
