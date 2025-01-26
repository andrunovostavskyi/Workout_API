using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RestFul.Models;
using System.ComponentModel.DataAnnotations;

namespace RestFul.Dto_s.Exercises
{
    public class CreateExerciseDTO
    {
        public string Name { get; set; } = default!;

        public int Sets { get; set; }

        public double Weight { get; set; }

        public int Duration { get; set; }

        public Guid WorkoutId { get; set; }
    }
}
