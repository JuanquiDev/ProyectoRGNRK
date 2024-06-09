using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RGNRK.Data;

public class RGNRKContext : IdentityDbContext<User>
{
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Benchmark> Benchmarks { get; set; }
    public DbSet<PersonalCalendar> PersonalCalendars { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Category> Categories { get; set; }

    public RGNRKContext(DbContextOptions<RGNRKContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configurar la relación entre User y Reserva
        builder.Entity<User>()
            .HasMany(u => u.Reservas)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId);

        // Configurar la relación entre Benchmark y Exercise
        builder.Entity<Benchmark>()
            .HasOne(b => b.Exercise)
            .WithMany(e => e.Benchmarks)
            .HasForeignKey(b => b.ExerciseId);

        // Configurar la relación entre Benchmark y User
        builder.Entity<Benchmark>()
            .HasOne(b => b.User)
            .WithMany(u => u.Benchmarks)
            .HasForeignKey(b => b.UserId);

        // Datos iniciales para categorías
        builder.Entity<Category>().ToTable("Category");
        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Basico" },
            new Category { Id = 2, Name = "Gimnásticos" },
            new Category { Id = 3, Name = "Halterofilia" },
            new Category { Id = 4, Name = "Accesorios" }
        );
    }

}
