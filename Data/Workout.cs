using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RGNRK.Data
{

    public class Workout
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [StringLength(3000)]
        public string? Description { get; set; }

        [Required]
        [Range(1, 1440)]
        public int Duration { get; set; }

        public int ExerciseId { get; set; }
        public DateTime? StartDate { get; set; }

        // Elimina PersonalCalendarId si no es necesario
        // public int? PersonalCalendarId { get; set; }

        // Relación con PersonalCalendarWorkout
        public virtual List<PersonalCalendarWorkout>? PersonalCalendarWorkouts { get; set; }
    }

}
