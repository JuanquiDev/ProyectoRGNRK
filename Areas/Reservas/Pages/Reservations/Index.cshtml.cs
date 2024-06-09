using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RGNRK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RGNRK.Areas.Reservas.Pages.Reservations
{
    public class ReservasModel : PageModel
    {
        private readonly RGNRKContext _context;

        public ReservasModel(RGNRKContext context)
        {
            _context = context;
            AvailableSlots = new List<DateTime>();
            ReservedSlots = new List<Reserva>();
            AvailableTrainers = new Dictionary<TimeSpan, List<Reserva.EntrenadorNombre>>();
        }

        [BindProperty(SupportsGet = true)]
        public DateTime SelectedDate { get; set; } = DateTime.Today;

        public List<DateTime> AvailableSlots { get; set; }
        public List<Reserva> ReservedSlots { get; set; }
        public Dictionary<TimeSpan, List<Reserva.EntrenadorNombre>> AvailableTrainers { get; set; }

        public async Task OnGetAsync(DateTime? selectedDate)
        {
            if (selectedDate.HasValue)
            {
                SelectedDate = selectedDate.Value;
            }
            else
            {
                SelectedDate = DateTime.Today;
            }

            // Get available and reserved slots
            AvailableSlots = GetAvailableSlots(SelectedDate);
            ReservedSlots = await GetReservedSlotsAsync(SelectedDate);

            // Define timeStart and timeEnd
            var timeStart = new TimeSpan(9, 0, 0); // 9 AM
            var timeEnd = new TimeSpan(21, 0, 0); // 9 PM

            // Get available trainers
            AvailableTrainers = await GetAvailableTrainersAsync(SelectedDate, timeStart, timeEnd);
        }

        public async Task<IActionResult> OnPostAsync(DateTime slot, Reserva.EntrenadorNombre entrenador, string horaInicio, string horaFin)
        {
            // Parse horaInicio and horaFin to TimeSpan
            var timeStart = TimeSpan.Parse(horaInicio);
            var timeEnd = TimeSpan.Parse(horaFin);

            // Check if the trainer is already booked at the same time
            var isTrainerBooked = await _context.Reservas.AnyAsync(r => r.Entrenador == entrenador && r.Fecha.Date == slot.Date && r.HoraInicio == timeStart && r.HoraFin == timeEnd);
            if (isTrainerBooked)
            {
                TempData["ErrorMessage"] = "Este entrenador ya ha sido reservado para este horario.";
                return RedirectToPage(new { selectedDate = SelectedDate.ToString("yyyy-MM-dd") });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var personalCalendar = await _context.PersonalCalendars
                .Include(c => c.PersonalCalendarReservas)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (personalCalendar == null)
            {
                personalCalendar = new PersonalCalendar
                {
                    UserId = userId,
                    PersonalCalendarReservas = new List<PersonalCalendarReserva>()
                };
                _context.PersonalCalendars.Add(personalCalendar);
                await _context.SaveChangesAsync();
            }

            var user = await _context.Users.FindAsync(userId);

            // Create a new reservation
            var reserva = new Reserva
            {
                Fecha = slot,
                StartDate = slot,
                EndDate = slot.AddHours(1), // Assuming each slot is 1 hour long
                HoraInicio = slot.TimeOfDay,
                HoraFin = slot.AddHours(1).TimeOfDay,
                UserId = userId,
                User = user,
                Entrenador = entrenador,
                Titulo = "Reserva de entrenamiento",
                PersonalCalendarReservas = new List<PersonalCalendarReserva>()
            };

            // Create a new PersonalCalendarReserva and add it to the reservation
            var personalCalendarReserva = new PersonalCalendarReserva
            {
                PersonalCalendarId = personalCalendar.Id,
                PersonalCalendar = personalCalendar,
                ReservaId = reserva.Id,
                Reserva = reserva
            };
            reserva.PersonalCalendarReservas.Add(personalCalendarReserva);

            // Add reservation to the database
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Reserva realizada con éxito.";
            return RedirectToPage(new { selectedDate = SelectedDate.ToString("yyyy-MM-dd") });
        }

        private List<DateTime> GetAvailableSlots(DateTime date)
        {
            // Assuming the slots are hourly from 9 AM to 9 PM
            var slots = new List<DateTime>();
            for (int hour = 9; hour < 21; hour++)
            {
                slots.Add(new DateTime(date.Year, date.Month, date.Day, hour, 0, 0));
            }
            return slots;
        }

        private async Task<Dictionary<TimeSpan, List<Reserva.EntrenadorNombre>>> GetAvailableTrainersAsync(DateTime date, TimeSpan timeStart, TimeSpan timeEnd)
        {
            // Get all trainers
            var allTrainers = new HashSet<Reserva.EntrenadorNombre>(Enum.GetValues(typeof(Reserva.EntrenadorNombre)).Cast<Reserva.EntrenadorNombre>());

            // Get all reservations for the selected date
            var reservations = await _context.Reservas
                .Where(r => r.Fecha.Date == date.Date)
                .ToListAsync();

            // Create a dictionary to store the available trainers for each slot
            var availableTrainersPerSlot = new Dictionary<TimeSpan, List<Reserva.EntrenadorNombre>>();

            // Iterate over each hour between timeStart and timeEnd
            for (var time = timeStart; time < timeEnd; time = time.Add(TimeSpan.FromHours(1)))
            {
                // Get all trainers who have a reservation at the current time
                var busyTrainers = reservations
                    .Where(r => r.HoraInicio <= time && r.HoraFin > time)
                    .Select(r => r.Entrenador)
                    .ToHashSet();

                // Get all trainers who are not busy at the current time
                var availableTrainers = allTrainers.Except(busyTrainers).ToList();

                // Add the available trainers to the dictionary
                availableTrainersPerSlot[time] = availableTrainers;
            }

            return availableTrainersPerSlot;
        }

        private async Task<List<Reserva>> GetReservedSlotsAsync(DateTime date)
        {
            return await _context.Reservas
                .Where(r => r.Fecha.Date == date.Date)
                .ToListAsync();
        }
    }
}

