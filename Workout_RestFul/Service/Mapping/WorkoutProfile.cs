using AutoMapper;
using RestFul.Dto_s;
using RestFul.Dto_s.Workouts;
using RestFul.Models;

namespace RestFul.Service.Mapping;

public class WorkoutProfile:Profile
{
    public WorkoutProfile()
    {
        CreateMap<Workout, WorkoutDTO>();

        CreateMap<Workout, WorkOutWithOutExercisesDTO>();

        CreateMap<CreateWorkoutDTO, Workout>();

        CreateMap<UpdateWorkoutDTO, Workout>();

        
    }
}
