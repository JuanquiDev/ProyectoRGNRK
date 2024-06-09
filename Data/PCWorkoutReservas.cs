namespace RGNRK.Data
{



    public class PersonalCalendarWorkout
    {
        public int PersonalCalendarId { get; set; }
        public virtual PersonalCalendar PersonalCalendar { get; set; }

        public int WorkoutId { get; set; }
        public virtual Workout Workout { get; set; }

        public DateTime AddedDate { get; set; }
    }

    public class PersonalCalendarReserva
    {
        public int PersonalCalendarId { get; set; }
        public virtual PersonalCalendar PersonalCalendar { get; set; }

        public int ReservaId { get; set; }
        public virtual Reserva Reserva { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime ReservationDate { get; set; } 

    }
}