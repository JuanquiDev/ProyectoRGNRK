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
}
