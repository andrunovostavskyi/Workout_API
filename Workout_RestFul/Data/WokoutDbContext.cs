using RestFul.Models;
using Microsoft.EntityFrameworkCore;

namespace RestFul.Data
{
    public class WorkoutDbContext: DbContext
    {
        public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        private void OnModel()
        {

        }
    }
}
