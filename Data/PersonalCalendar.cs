﻿namespace RGNRK.Data;

public class PersonalCalendar
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public virtual List<Workout> Workout { get; set; }
}
