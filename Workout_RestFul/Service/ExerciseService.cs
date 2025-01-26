using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestFul.Data;
using RestFul.Dto_s.Exercises;
using RestFul.Dto_s.Workouts;
using RestFul.Middlewares.Exceptions;
using RestFul.Models;
using RestFul.Service.Interface;

namespace RestFul.Service
{
    internal class ExerciseService:IExerciseService
    {
        private readonly IMapper _mapper;
        private readonly WorkoutDbContext _context;

        public ExerciseService(WorkoutDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ExerciseDTO>> GetAll()
        {
            List<Exercise> exercises = await _context.Exercises.Include(i=>i.Workouts).ToListAsync();
            var exercicesDTO = exercises.Select(m => new ExerciseDTO
            {
                Name = m.Name,
                Duration = m.Duration, 
                Sets = m.Sets,
                Weight = m.Weight,
                Workouts = m.Workouts.Select(s=> new WorkOutWithOutExercisesDTO
                {
                    Id = s.Id,
                    Description = s.Description,    
                    Name = s.Name,
                }).ToList(),
            }).ToList();
            return exercicesDTO;
        }

        public async Task<ExerciseDTO> GetById(Guid id)
        {
            Exercise? exercise = await _context.Exercises.FindAsync(id);
            if(exercise == null)
            {
                throw new NotFoundExceptions(nameof(Exercise), id.ToString());
            }

            var workout = _mapper.Map<List<WorkOutWithOutExercisesDTO>>(exercise.Workouts);
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            exerciseDTO.Workouts = workout;
            return exerciseDTO;
        }

        public async Task<Guid> Add(CreateExerciseDTO addNewExercise)
        {
            var exercise = new Exercise();

            var workout = await _context.Workouts.FirstOrDefaultAsync(f=>f.Id == addNewExercise.WorkoutId);
            if(workout  == null)
            {
                throw new NotFoundExceptions(nameof(Workout), addNewExercise.WorkoutId.ToString());
            }

            exercise.Workouts!.Add(workout);
            _mapper.Map(addNewExercise,exercise);

            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            return exercise.Id;
        }

        public async Task<ExerciseDTO> Update(Guid id, UpdateExerciseDTO exerciseForUpdate)
        {
            Exercise? exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                throw new NotFoundExceptions(nameof(Exercise), id.ToString());
            }

             _mapper.Map(exerciseForUpdate, exercise);
            await _context.SaveChangesAsync();

            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return exerciseDTO;
        }

        public async Task Delete(Guid id)
        {
            Exercise? forDelete = await _context.Exercises.FindAsync(id);
            if (forDelete == null)
            {
                throw new NotFoundExceptions(nameof(Exercise), id.ToString());
            }
            
            _context.Remove(forDelete);
            await _context.SaveChangesAsync();
        }
    }
}
