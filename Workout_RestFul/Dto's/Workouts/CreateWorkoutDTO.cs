namespace RestFul.Dto_s;

public class CreateWorkoutDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid ExerciseId { get; set; }
}
