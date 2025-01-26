namespace RestFul.Dto_s.Exercises
{
    public class UpdateExerciseDTO
    {
        public string Name { get; set; } = default!;

        public int Sets { get; set; }

        public double Weight { get; set; }

        public int Duration { get; set; }

    }
}
