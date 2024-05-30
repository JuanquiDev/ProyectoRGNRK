using Microsoft.AspNetCore.Identity;
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
            standar,
            advanced
        }

        public Category UserCategory { get; set; }

        public virtual ICollection<Reserva>? Reservas { get; set; }
    }

    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Entrenador { get; set; }
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
