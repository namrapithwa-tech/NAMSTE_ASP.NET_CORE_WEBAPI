using CoffeeShopWEBAPI.Data;
using CoffeeShopWEBAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryRepository _countryRepository;

        public CountryController(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = _countryRepository.SelectAll();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _countryRepository.SelectByPK(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public IActionResult InsertCountry([FromBody] CountryModel country)
        {
            if (country == null)
            {
                return BadRequest("Invalid country data.");
            }

            var isInserted = _countryRepository.Insert(country);
            if (!isInserted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to insert country.");
            }

            return CreatedAtAction(nameof(GetCountryById), new { id = country.CountryID }, country);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, [FromBody] CountryModel country)
        {
            if (country == null || id != country.CountryID)
            {
                return BadRequest("Invalid country data.");
            }

            var isUpdated = _countryRepository.Update(country);
            if (!isUpdated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update country.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var isDeleted = _countryRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
