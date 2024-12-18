using CoffeeShopWEBAPI.Data;
using CoffeeShopWEBAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityRepository _cityRepository;

        public CityController(CityRepository cityRepository)
        {

            _cityRepository = cityRepository;

        }

        [HttpGet]

        public ActionResult GetAllCities()
        {

            var cities = _cityRepository.SelectAll();

            return Ok(cities);

        }

        [HttpGet("{id}")]

        public IActionResult GetCityById(int id)
        {

            var city = _cityRepository.SelectByPK(id);

            if (city == null)

            {

                return NotFound();

            }

            return Ok(city);

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteCity(int id)
        {

            var isDeleted = _cityRepository.Delete(id);

            if (!isDeleted)

            {
                    
            }

            return NotFound();

            return NoContent();

        }

        [HttpPost]
        public IActionResult InsertCity([FromBody] CityModel city)
        {
            if (city == null)
            {
                return BadRequest("City data is invalid.");
            }

            var isInserted = _cityRepository.Insert(city);
            if (!isInserted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to insert city.");
            }

            return CreatedAtAction(nameof(GetCityById), new { id = city.CityID }, city);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] CityModel city)
        {
            if (city == null || id != city.CityID)
            {
                return BadRequest("City data is invalid.");
            }

            var isUpdated = _cityRepository.Update(city);
            if (!isUpdated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update city.");
            }

            return NoContent();
        }


    }
}
