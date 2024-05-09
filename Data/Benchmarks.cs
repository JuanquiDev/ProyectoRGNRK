namespace RGNRK.Data;

public class Benchmarks
{
    public int Id { get; set; }
    public int personalRecords { get; set; }
    public DateTime Date { get; set; }
    public virtual List<Exercise> Exercise { get; set; }
}
