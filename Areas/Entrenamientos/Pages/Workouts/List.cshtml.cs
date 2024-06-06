using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using RGNRK.Configuracion;
using RGNRK.Data;
using Microsoft.EntityFrameworkCore;

public class EntrenamientosModel : PageModel
{
    private readonly RGNRKContext _context;

    public EntrenamientosModel(RGNRKContext context)
    {
        _context = context;
        Exercises = new List<Exercise>(); // Inicializar a lista vacía
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

    public IActionResult OnPost()
    {
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