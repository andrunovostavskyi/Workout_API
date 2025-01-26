using RestFul.Dto_s.Workouts;
using RestFul.Models;

namespace RestFul.Dto_s.Exercises
{
    public class ExerciseDTO
    {
        public string Name { get; set; } = default!;

        public int Sets { get; set; }

        public double Weight { get; set; }

        public int Duration { get; set; }

        public List<WorkOutWithOutExercisesDTO> Workouts { get; set; } = new List<WorkOutWithOutExercisesDTO>();
    }
}
