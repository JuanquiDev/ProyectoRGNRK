namespace RGNRK.Data;

public class Workout
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public virtual List<Exercise> Exercise { get; set; }

}
