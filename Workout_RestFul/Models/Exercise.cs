using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestFul.Models
{
    public class Exercise
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; } = default!;

        public int Sets { get; set; }

        public double Weight {  get; set; }

        public int Duration {  get; set; }
        
        public List<Workout>? Workouts { get; set; }
    }
}
