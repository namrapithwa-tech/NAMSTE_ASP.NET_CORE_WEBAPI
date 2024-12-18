using CoffeeShopWEBAPI.Data;
using CoffeeShopWEBAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateRepository _stateRepository;

        public StateController(StateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpGet]
        public IActionResult GetAllStates()
        {
            var states = _stateRepository.SelectAll();
            return Ok(states);
        }

        [HttpGet("{id}")]
        public IActionResult GetStateById(int id)
        {
            var state = _stateRepository.SelectByPK(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }

        [HttpPost]
        public IActionResult InsertState([FromBody] StateModel state)
        {
            if (state == null)
            {
                return BadRequest("Invalid state data.");
            }

            var isInserted = _stateRepository.Insert(state);
            if (!isInserted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to insert state.");
            }

            return CreatedAtAction(nameof(GetStateById), new { id = state.StateID }, state);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateState(int id, [FromBody] StateModel state)
        {
            if (state == null || id != state.StateID)
            {
                return BadRequest("Invalid state data.");
            }

            var isUpdated = _stateRepository.Update(state);
            if (!isUpdated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update state.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteState(int id)
        {
            var isDeleted = _stateRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
