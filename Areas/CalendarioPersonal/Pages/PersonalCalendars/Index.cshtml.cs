using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RGNRK.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

public class PersonalCalendarModel : PageModel
{
    private readonly RGNRKContext _context;

    public PersonalCalendarModel(RGNRKContext context)
    {
        _context = context;
        Workouts = new List<Workout>();
        Reservas = new List<Reserva>();
    }

    public List<Workout> Workouts { get; set; }
    public List<Reserva> Reservas { get; set; }

    public async Task OnGetAsync()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId != null)
        {
            var personalCalendar = await _context.PersonalCalendars
                .Include(c => c.PersonalCalendarWorkouts)
                    .ThenInclude(pcw => pcw.Workout)
                .Include(c => c.PersonalCalendarReservas)
                    .ThenInclude(pcr => pcr.Reserva)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (personalCalendar != null)
            {
                Workouts = personalCalendar.PersonalCalendarWorkouts.Select(pcw => pcw.Workout).ToList();
                Reservas = personalCalendar.PersonalCalendarReservas.Select(pcr => pcr.Reserva).ToList();
            }
        }
    }


    public async Task<IActionResult> OnPostDeleteReservaAsync(int reservaId)
    {
        var personalCalendarReserva = await _context.PersonalCalendarReservas
            .FirstOrDefaultAsync(pcr => pcr.ReservaId == reservaId);

        if (personalCalendarReserva != null)
        {
            _context.PersonalCalendarReservas.Remove(personalCalendarReserva);

            var reserva = await _context.Reservas.FirstOrDefaultAsync(r => r.Id == reservaId);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }

            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }


    public async Task<IActionResult> OnPostDeleteWorkoutAsync(int workoutId)
    {
        var personalCalendarWorkout = await _context.PersonalCalendarWorkouts
            .FirstOrDefaultAsync(pcw => pcw.WorkoutId == workoutId);

        if (personalCalendarWorkout != null)
        {
            _context.PersonalCalendarWorkouts.Remove(personalCalendarWorkout);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}
