using System.ComponentModel.DataAnnotations;

namespace RGNRK.Data
{
    public class Workout
    {
        public int Id { get; set; }


        [StringLength(3000)]
        public string? Description { get; set; }

        [Required]
        [Range(1, 1440)] 
        public int Duration { get; set; }
        public int ExerciseId { get; set; } 
    }
}
