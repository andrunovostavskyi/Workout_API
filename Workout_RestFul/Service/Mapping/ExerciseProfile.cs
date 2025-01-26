using AutoMapper;
using RestFul.Dto_s.Exercises;
using RestFul.Models;

namespace RestFul.Service.Mapping
{
    public class ExerciseProfile: Profile
    {
        public ExerciseProfile()
        {
            CreateMap<CreateExerciseDTO, Exercise>();

            CreateMap<Exercise, ExerciseDTO>();

            CreateMap<UpdateExerciseDTO, Exercise>();

            CreateMap<Exercise,ExerciseWithOutWorkoutsDTO>();
        }
    }
}
