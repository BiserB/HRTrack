using Microsoft.AspNetCore.Identity;

namespace HRTrack.Entities
{
    public class AppUser : IdentityUser
    {
        public int ClusterId { get; set; }

        public bool EmailNotificationsEnabled { get; set; }
    }
}