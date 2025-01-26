using Microsoft.AspNetCore.Mvc;
using RestFul.Dto_s.Exercises;
using RestFul.Service.Interface;

namespace RestFul.Controllers
{
    [ApiController]
    [Route("app/[controller]")]
    public class ExerciseController : Controller
    {
        public readonly IExerciseService _exersices;

        public ExerciseController(IExerciseService exersices)
        {
            _exersices = exersices;
        }

        [HttpGet]
        public async Task<ActionResult> Get() 
        {
            return Ok( await _exersices.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _exersices.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateExerciseDTO newExerciseDTO)
        {
            return CreatedAtAction(nameof(Get), await _exersices.Add(newExerciseDTO));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateExerciseDTO updateExercise)
        {
            return Ok( await _exersices.Update(id, updateExercise));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _exersices.Delete(id);
            return NoContent();
        }

    }
}
