using RestFul.Dto_s;
using RestFul.Dto_s.Workouts;
using RestFul.Models;

namespace RestFul.Service.Interface
{
    public interface IWorkoutService
    {
        Task<List<WorkoutDTO>> GetAll();
        Task<WorkoutDTO> GetById(Guid id);
        Task<Guid> Add(CreateWorkoutDTO workout);
        Task<WorkoutDTO> Update(Guid id, UpdateWorkoutDTO workout);
        Task Delete(Guid id);
    }
}
