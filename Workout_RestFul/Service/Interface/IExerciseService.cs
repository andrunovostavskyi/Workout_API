using RestFul.Dto_s.Exercises;
using RestFul.Models;

namespace RestFul.Service.Interface
{
    public interface IExerciseService
    {
        Task<List<ExerciseDTO>> GetAll();
        Task<ExerciseDTO> GetById(Guid id);
        Task<Guid> Add(CreateExerciseDTO workout);
        Task<ExerciseDTO> Update(Guid id, UpdateExerciseDTO workout);
        Task Delete(Guid id);
    }
}
