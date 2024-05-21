using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RGNRK.Data;

public class RGNRKContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Users> Users { get; set; }
    public DbSet<Workout> Workout { get; set; }
    public DbSet<Exercise> Exercise { get; set; }
    public DbSet<Benchmarks> Benchmarks { get; set; }
    public DbSet<PersonalCalendar> PersonalCalendar { get; set; }

    public RGNRKContext(DbContextOptions<RGNRKContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
