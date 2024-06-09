using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RGNRK.Data;
using System.Linq;
using System.Threading.Tasks;


public class EditModel : PageModel
{
    private readonly RGNRKContext _context;

    public EditModel(RGNRKContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Workout Workout { get; set; }

    public async Task<IActionResult> OnGetAsync(int WorkoutId)
    {
        Workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == WorkoutId);
        if (Workout == null)
        {
            return NotFound();
        }
        return Page();
    }

    

    public async Task<IActionResult> OnPostAsync()
    {

        if (!ModelState.IsValid)
        {
            Console.WriteLine("Modelo no válido");
            return Page();
        }

        var workoutToUpdate = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == Workout.Id);
        if (workoutToUpdate == null)
        {
            return NotFound();
        }

        workoutToUpdate.Description = Workout.Description;
        workoutToUpdate.Duration = Workout.Duration;
        workoutToUpdate.ExerciseId = Workout.ExerciseId;

        _context.Workouts.Update(workoutToUpdate);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Workouts/List", new {area = "Entrenamientos", SelectedExerciseId = Workout.ExerciseId });
    }
}