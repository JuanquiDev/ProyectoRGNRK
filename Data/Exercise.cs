namespace RGNRK.Data
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Video? ExerciseVideo { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        
        public virtual List<Benchmarks> Benchmarks { get; set; }
        public virtual List<Workout> Workout { get; set; }
    }
}
