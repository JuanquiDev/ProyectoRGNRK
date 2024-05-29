using Microsoft.AspNetCore.Identity;

namespace RGNRK.Data
{
    public class User :IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public enum Category
        {
            basic,
            standar,
            advanced
        }

        public Category UserCategory { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; } 
    }

    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Entrenador { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}