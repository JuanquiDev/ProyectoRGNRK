namespace RGNRK.Data
{
    public class Benchmark
    {
        public Benchmark()
        {
            PersonalRecords = 0;
        }

        public int? Id { get; set; }
        public int PersonalRecords { get; set; }
        public DateTime Date { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise? Exercise { get; set; }
        public string UserId { get; set; }
        public virtual User? User { get; set; }
    }
}