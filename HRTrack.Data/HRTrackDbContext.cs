using HRTrack.Entities;
using Microsoft.AspNetCore.Identity;
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

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<AppUser>().HasKey(e => e.Id).IsClustered(false);
            mb.Entity<AppUser>().HasIndex(e => e.ClusterId).IsClustered();

        }
    }
}