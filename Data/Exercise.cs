namespace RGNRK.Data
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public class Video
        {
            public string Title { get; set; }
            public string Url { get; set; }
        }
        public virtual List<Benchmarks> Benchmarks { get; set; }
        public virtual List<Workout> Workout { get; set; }
    }
}
