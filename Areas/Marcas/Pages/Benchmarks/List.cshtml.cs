using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RGNRK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RGNRK.Areas.Marcas.Pages.Benchmarks
{
    public class ListModel : PageModel
    {
        private readonly RGNRKContext _context;

        public ListModel(RGNRKContext context)
        {
            _context = context;
        }

        public IList<Exercise> Exercises { get; set; }

        [BindProperty]
        public IList<Benchmark> InputBenchmarks { get; set; }

        public async Task OnGetAsync()
        {
            await LoadExercisesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validar el modelo
            if (!ModelState.IsValid)
            {
                // Si hay errores en el modelo, muestra los mensajes de error y devuelve la página
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Error en {state.Key}: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            // Validar que todos los InputBenchmarks tengan valores válidos
            foreach (var inputBenchmark in InputBenchmarks)
            {
                if (inputBenchmark.PersonalRecords <= 0)
                {
                    ModelState.AddModelError("", "Todos los registros personales deben ser mayores a 0.");
                    return Page();
                }
            }

            // Buscar al usuario actual
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Iterar sobre los InputBenchmarks y actualizar o crear Benchmark según sea necesario
            foreach (var inputBenchmark in InputBenchmarks)
            {
                // Buscar el Benchmark correspondiente a este ejercicio y usuario
                var benchmark = await _context.Benchmarks
                    .FirstOrDefaultAsync(b => b.ExerciseId == inputBenchmark.ExerciseId && b.UserId == user.Id);

                if (benchmark == null)
                {
                    // Si no existe, crear uno nuevo
                    benchmark = new Benchmark
                    {
                        ExerciseId = inputBenchmark.ExerciseId,
                        PersonalRecords = inputBenchmark.PersonalRecords,
                        Date = DateTime.Today,
                        UserId = user.Id
                    };
                    _context.Benchmarks.Add(benchmark);
                }
                else
                {
                    // Si existe, actualizar el PersonalRecords
                    benchmark.PersonalRecords = inputBenchmark.PersonalRecords;
                    benchmark.Date = DateTime.Today;

                    // Marcar la entidad como modificada para que se actualice en la base de datos
                    _context.Benchmarks.Update(benchmark);
                }
            }

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Después de guardar los cambios, redirigir a la página actual
            return RedirectToPage();
        }


        private async Task LoadExercisesAsync()
        {
            // Cargar todos los ejercicios de la categoría "Halterofilia" con sus respectivos Benchmarks
            Exercises = await _context.Exercises
                .Include(e => e.Benchmarks)
                .Where(e => e.Category.Name == "Halterofilia")
                .ToListAsync();

            // Buscar al usuario actual
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Inicializar los InputBenchmarks con los benchmarks existentes o con nuevos benchmarks con PersonalRecords = 0
            InputBenchmarks = Exercises.Select(e =>
            {
                var benchmark = e.Benchmarks.FirstOrDefault(b => b.UserId == userId);
                if (benchmark == null)
                {
                    benchmark = new Benchmark
                    {
                        ExerciseId = e.Id,
                        PersonalRecords = 0,
                        Date = DateTime.Today,
                        UserId = userId
                    };
                    _context.Benchmarks.Add(benchmark);  // Agregar nuevos benchmarks a la base de datos
                }
                return benchmark;
            }).ToList();

            // Guardar los nuevos benchmarks en la base de datos
            await _context.SaveChangesAsync();
        }
    }
}
