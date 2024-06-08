using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RGNRK.Data;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RGNRK.Areas.CalendarioPersonal.Pages.PersonalCalendars
{
    public class AddEventModel : PageModel
    {
        private readonly RGNRKContext _context;

        [BindProperty]
        public Workout Workout { get; set; }
        [BindProperty]
        public Reserva Reserva { get; set; }

        public AddEventModel(RGNRKContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var personalCalendar = await _context.PersonalCalendars
                .Include(c => c.PersonalCalendarWorkouts)
                .Include(c => c.PersonalCalendarReservas)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (personalCalendar == null)
            {
                personalCalendar = new PersonalCalendar
                {
                    UserId = userId,
                    PersonalCalendarWorkouts = new List<PersonalCalendarWorkout>(),
                    PersonalCalendarReservas = new List<PersonalCalendarReserva>()
                };
                _context.PersonalCalendars.Add(personalCalendar);
            }

            if (Workout != null)
            {
                var existingWorkout = await _context.Workouts.FindAsync(Workout.Id);
                if (existingWorkout == null)
                {
                    _context.Workouts.Add(Workout);
                    await _context.SaveChangesAsync();
                    existingWorkout = Workout;
                }

                var personalCalendarWorkout = new PersonalCalendarWorkout
                {
                    PersonalCalendarId = personalCalendar.Id,
                    WorkoutId = existingWorkout.Id,
                    AddedDate = DateTime.Now
                };

                personalCalendar.PersonalCalendarWorkouts.Add(personalCalendarWorkout);
            }

            if (Reserva != null)
            {
                var existingReserva = await _context.Reservas.FindAsync(Reserva.Id);
                if (existingReserva == null)
                {
                    _context.Reservas.Add(Reserva);
                    await _context.SaveChangesAsync();
                    existingReserva = Reserva;
                }

                var personalCalendarReserva = new PersonalCalendarReserva
                {
                    PersonalCalendarId = personalCalendar.Id,
                    ReservaId = existingReserva.Id,
                    AddedDate = DateTime.Now
                };

                personalCalendar.PersonalCalendarReservas.Add(personalCalendarReserva);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
