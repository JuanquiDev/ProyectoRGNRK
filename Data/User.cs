using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RGNRK.Data
{
    public class User : IdentityUser
    {
        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [Range(0, 300)]
        public int? Height { get; set; }

        [Range(0, 500)]
        public int? Weight { get; set; }

        public enum Category
        {
            basic,
            standard,
            advanced
        }

        public Category UserCategory { get; set; }

        public virtual ICollection<Reserva>? Reservas { get; set; }
        public virtual ICollection<Benchmark>? Benchmarks { get; set; }
    }

    public class Reserva
    {
        public enum EntrenadorNombre
        {
            Abel,
            Luis,
            Alberto
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public EntrenadorNombre Entrenador { get; set; }
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime StartDate { get; set; }  // Hora de inicio de la reserva
        public DateTime EndDate { get; set; }    // Hora de fin de la reserva
        public string? Titulo { get; set; }

        public virtual List<PersonalCalendarReserva>? PersonalCalendarReservas { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }

}
