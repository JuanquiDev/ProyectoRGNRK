using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RGNRK.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RGNRK.Areas.Ejercicios.Pages.Exercises
{
    public class ListModel : PageModel
    {
        private readonly RGNRKContext _context;

        public ListModel(RGNRKContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories
                .Include(c => c.Exercises)
                    .ThenInclude(e => e.ExerciseVideo)
                .ToListAsync();
        }
    }
}
