namespace RestFul.Dto_s.Workouts
{
    public class WorkOutWithOutExercisesDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;
    }
}
