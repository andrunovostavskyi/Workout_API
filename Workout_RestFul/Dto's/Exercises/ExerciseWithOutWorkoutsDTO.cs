namespace RestFul.Dto_s.Exercises
{
    public class ExerciseWithOutWorkoutsDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public int Sets { get; set; }

        public double Weight { get; set; }

        public int Duration { get; set; }
    }
}
