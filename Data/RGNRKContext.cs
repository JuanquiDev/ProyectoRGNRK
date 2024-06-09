using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RGNRK.Data
{
    public class RGNRKContext : IdentityDbContext<User>
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Benchmark> Benchmarks { get; set; }
        public DbSet<PersonalCalendar> PersonalCalendars { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PersonalCalendarWorkout> PersonalCalendarWorkouts { get; set; }
        public DbSet<PersonalCalendarReserva> PersonalCalendarReservas { get; set; }

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

            // Configuración de la clave compuesta para PersonalCalendarWorkout
            builder.Entity<PersonalCalendarWorkout>()
                .HasKey(pcw => new { pcw.PersonalCalendarId, pcw.WorkoutId });

            builder.Entity<PersonalCalendarWorkout>()
                .HasOne(pcw => pcw.PersonalCalendar)
                .WithMany(pc => pc.PersonalCalendarWorkouts)
                .HasForeignKey(pcw => pcw.PersonalCalendarId);

            builder.Entity<PersonalCalendarWorkout>()
                .HasOne(pcw => pcw.Workout)
                .WithMany(w => w.PersonalCalendarWorkouts)
                .HasForeignKey(pcw => pcw.WorkoutId);

            // Configuración de la clave compuesta para PersonalCalendarReserva
            builder.Entity<PersonalCalendarReserva>()
                .HasKey(pcr => new { pcr.PersonalCalendarId, pcr.ReservaId });

            builder.Entity<PersonalCalendarReserva>()
                .HasOne(pcr => pcr.PersonalCalendar)
                .WithMany(pc => pc.PersonalCalendarReservas)
                .HasForeignKey(pcr => pcr.PersonalCalendarId);

            builder.Entity<PersonalCalendarReserva>()
                .HasOne(pcr => pcr.Reserva)
                .WithMany(r => r.PersonalCalendarReservas)
                .HasForeignKey(pcr => pcr.ReservaId);

            // Configuración de mapeo personalizado para EntrenadorNombre
            builder.Entity<Reserva>()
                .Property(r => r.Entrenador)
                .HasConversion<string>();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Detectar las entidades que se están agregando
            var newUsers = ChangeTracker.Entries<User>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity)
                .ToList();

            var result = await base.SaveChangesAsync(cancellationToken);

            // Crear un PersonalCalendar para cada User nuevo
            foreach (var user in newUsers)
            {
                var personalCalendar = new PersonalCalendar
                {
                    UserId = user.Id
                };
                PersonalCalendars.Add(personalCalendar);
            }

            await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}