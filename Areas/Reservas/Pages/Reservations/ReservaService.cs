using RGNRK.Data;
namespace RGNRK.Areas.Reservas.Pages.Reservations
{



    public class ReservaService
    {
        private readonly RGNRKContext _context;

        public ReservaService(RGNRKContext context)
        {
            _context = context;
        }

        public List<DateTime> GetAvailableSlots(DateTime date)
        {
            var availableSlots = new List<DateTime>();
            var startTimes = new List<DateTime>();

            for (int hour = 9; hour < 14; hour++)
            {
                startTimes.Add(date.Date.AddHours(hour));
            }

            for (int hour = 17; hour < 21; hour++)
            {
                startTimes.Add(date.Date.AddHours(hour));
            }

            var reservedSlots = _context.Reservas
                .Where(r => r.Fecha.Date == date.Date)
                .Select(r => r.StartDate)
                .ToList();

            foreach (var startTime in startTimes)
            {
                if (!reservedSlots.Contains(startTime))
                {
                    availableSlots.Add(startTime);
                }
            }

            return availableSlots;
        }

        public void AddReserva(string userId, DateTime startDate, Reserva.EntrenadorNombre entrenador)
        {
            var endDate = startDate.AddHours(1);

            var reserva = new Reserva
            {
                Fecha = startDate.Date,
                StartDate = startDate,
                EndDate = endDate,
                Entrenador = entrenador,
                UserId = userId
            };

            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

    }
}
