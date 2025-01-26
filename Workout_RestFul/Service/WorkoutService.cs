using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestFul.Data;
using RestFul.Dto_s;
using RestFul.Dto_s.Exercises;
using RestFul.Dto_s.Workouts;
using RestFul.Middlewares.Exceptions;
using RestFul.Models;
using RestFul.Service.Interface;

namespace RestFul.Service
{
    internal class WorkoutService: IWorkoutService
    {
        private readonly WorkoutDbContext _context;
        private readonly IMapper _mapper;

        public WorkoutService(WorkoutDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<WorkoutDTO>> GetAll()
        {
            var workouts = await _context.Workouts
                .Include(w => w.Exercises)
                .ToListAsync();

            var workoutsDTO = workouts.Select(w => new WorkoutDTO
            {
                Id = w.Id,
                Name = w.Name,
                Description = w.Description,
                Exercises = w.Exercises!.Select(e => new ExerciseWithOutWorkoutsDTO
                {
                    Id = e.Id,
                    Name = e.Name
                }).ToList()
            }).ToList();

            return workoutsDTO;
        }


        public async Task<WorkoutDTO> GetById(Guid id)
        {
            var workout = await _context.Workouts.Include(i=>i.Exercises).FirstOrDefaultAsync(f=>f.Id==id);
            if(workout == null)
                throw new NotFoundExceptions(nameof(Workout), id.ToString());

            var exercises = _mapper.Map<List<ExerciseWithOutWorkoutsDTO>>(workout.Exercises);
            var workoutDTO = _mapper.Map<WorkoutDTO>(workout);
            workoutDTO.Exercises = exercises;
            return workoutDTO;
        }

        public async Task<Guid> Add(CreateWorkoutDTO request)
        {
            Workout workout = new Workout()
            {
                Exercises = new List<Exercise>()
            };

            var exercise = await _context.Exercises.FirstOrDefaultAsync(f => f.Id == request.ExerciseId);
            if (exercise is null)
                throw new NotFoundExceptions(nameof(Exercise), request.ExerciseId.ToString());

            workout.Exercises.Add(exercise);
            _mapper.Map(request, workout);
            await _context.Workouts.AddAsync(workout);
            await _context.SaveChangesAsync();
            return workout.Id;
        }

        public async Task<WorkoutDTO> Update(Guid id, UpdateWorkoutDTO updateWorkout)
        {
            Workout? workout = await _context.Workouts.FirstOrDefaultAsync(u => u.Id == id);
            if (workout is null)
                throw new NotFoundExceptions(nameof(Workout), id.ToString());

            _mapper.Map(updateWorkout,workout);
            await _context.SaveChangesAsync();

            var workoutDTO = _mapper.Map<WorkoutDTO>(workout);
            return workoutDTO;
        }

        public async Task Delete(Guid id)
        {
            Workout deleteWorkout = _context.Workouts.FirstOrDefault(d => d.Id == id)!;
            if (deleteWorkout is null)
                throw new NotFoundExceptions(nameof(Workout), id.ToString());

            _context.Workouts.Remove(deleteWorkout);
            await _context.SaveChangesAsync();
        }
    }
}
