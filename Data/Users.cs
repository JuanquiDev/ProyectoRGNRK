namespace RGNRK.Data
{
    public class Users
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; } // Agrega esta propiedad

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }
        public string Email { get; set; }

        public enum Category
        {
            basic,
            standar,
            advanced
        }

        public Category UserCategory { get; set; }

        public ICollection<Reserva> Reservas { get; set; } 
    }

    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Entrenador { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
    }
}