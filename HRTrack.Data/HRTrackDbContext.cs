using HRTrack.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRTrack.Data
{
    public class HRTrackDbContext : IdentityDbContext<AppUser>
    {
        public HRTrackDbContext(DbContextOptions<HRTrackDbContext> options)
            : base(options)
        {
        }
    }
}