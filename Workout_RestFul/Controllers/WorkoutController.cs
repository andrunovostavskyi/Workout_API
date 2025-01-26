using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFul.Dto_s;
using RestFul.Dto_s.Workouts;
using RestFul.Models;
using RestFul.Service.Interface;

namespace RestFul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        public readonly IWorkoutService _workout;
        public WorkoutController(IWorkoutService workout)
        {
            _workout = workout;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        { 
            return Ok(await _workout.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _workout.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateWorkoutDTO request)
        {
            return CreatedAtAction(nameof(Get), await _workout.Add(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateWorkoutDTO updateWorkout)
        {
            return Ok(await _workout.Update(id, updateWorkout));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _workout.Delete(id);
            return NoContent();
        }
    }
}
