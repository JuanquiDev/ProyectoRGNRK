using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using RGNRK.Configuracion;
using RGNRK.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class EntrenamientosModel : PageModel
{
    private readonly RGNRKContext _context;

    public EntrenamientosModel(RGNRKContext context)
    {
        _context = context;
        Exercises = new List<Exercise>(); // Inicializar a lista vac�a
        SelectedExercise = null; // Inicializar a null
    }

    [BindProperty(SupportsGet = true)]
    public int? SelectedExerciseId { get; set; }

    public List<Exercise> Exercises { get; set; }

    public Exercise SelectedExercise { get; set; }

    public void OnGet()
    {
        Exercises = _context.Exercises
            .Include(e => e.ExerciseVideo)
            .Include(e => e.Workout)
            .ToList();

        if (SelectedExerciseId.HasValue && SelectedExerciseId.Value > 0)
        {
            SelectedExercise = _context.Exercises
                .Include(e => e.ExerciseVideo)
                .Include(e => e.Workout)
                .FirstOrDefault(e => e.Id == SelectedExerciseId.Value);
        }
    }

    public async Task<IActionResult> OnPostAsync(string actionType, int workoutId)
    {
        if (actionType == "addToCalendar")
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var personalCalendar = await _context.PersonalCalendars
                .Include(c => c.PersonalCalendarWorkouts)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (personalCalendar == null)
            {
                personalCalendar = new PersonalCalendar
                {
                    UserId = userId,
                    PersonalCalendarWorkouts = new List<PersonalCalendarWorkout>()
                };
                _context.PersonalCalendars.Add(personalCalendar);
            }

            var selectedExercise = await _context.Exercises
                .Include(e => e.Workout)
                .FirstOrDefaultAsync(e => e.Id == SelectedExerciseId.Value);

            if (selectedExercise != null && selectedExercise.Workout != null && selectedExercise.Workout.Any())
            {
                var personalCalendarWorkout = new PersonalCalendarWorkout
                {
                    PersonalCalendarId = personalCalendar.Id,
                    WorkoutId = workoutId,
                    AddedDate = DateTime.Now
                };

                if (personalCalendar.PersonalCalendarWorkouts.All(pcw => pcw.WorkoutId != workoutId))
                {
                    personalCalendar.PersonalCalendarWorkouts.Add(personalCalendarWorkout);
                    await _context.SaveChangesAsync();
                }
            }

            TempData["Message"] = "El entrenamiento ha sido a�adido a tu Calendario";
            return RedirectToPage();
        }

        // L�gica existente para otras acciones
        if (User.IsInRole(Permissions.Admin_Role) ||
            User.IsInRole(Permissions.Manager_Role) ||
            User.IsInRole(Permissions.Coach_Role))
        {
            var workout = new Workout
            {
                Description = SelectedExercise.Workout.First().Description,
                Duration = 60,
                ExerciseId = SelectedExercise.Id
            };

            _context.Workouts.Add(workout);
            _context.SaveChanges();
        }

        return RedirectToPage(new { SelectedExerciseId });
    }
}