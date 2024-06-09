using System.Collections.Generic;
namespace RGNRK.Data
{ 
    public class PersonalCalendar
{
    public int Id { get; set; }
    public string? UserId { get; set; }

    // Relación con PersonalCalendarWorkout
    public virtual List<PersonalCalendarWorkout>? PersonalCalendarWorkouts { get; set; }

    // Relación con PersonalCalendarReserva
    public virtual List<PersonalCalendarReserva>? PersonalCalendarReservas { get; set; }
}
}
