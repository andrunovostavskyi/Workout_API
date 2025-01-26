using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFul.Models
{
    public class Workout
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; } = default!;

        [MaxLength(10000)]
        public string Description { get; set; } = default!;

        public List<Exercise>? Exercises { get; set; }
    }
}
