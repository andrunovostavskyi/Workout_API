using RestFul.Dto_s.Exercises;

namespace RestFul.Dto_s.Workouts;

public class WorkoutDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public List<ExerciseWithOutWorkoutsDTO> Exercises { get; set; } = new List<ExerciseWithOutWorkoutsDTO>();
}
