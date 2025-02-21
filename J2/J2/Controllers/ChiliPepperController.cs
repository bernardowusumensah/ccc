using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace J2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiliPepperController : ControllerBase
    {
        // Step 1: Define SHU values in a dictionary
        private static readonly Dictionary<string, int> myChillies = new Dictionary<string, int>
        {
            {"Poblano", 1500},
            {"Mirasol", 6000},
            {"Serrano", 15500},
            {"Cayenne", 40000},
            {"Thai", 75000},
            {"Habanero", 125000}

        };

        /// <summary>
        /// Get total SHU of chili peppers
        /// </summary>
        /// <param name="Ingredients"></param>
        /// <returns>
        /// returns total SHU of chili peppers
        /// </returns>
        /// <example>GET api/J2/ChiliPeppers?Ingredients=Poblano,Mirasol,Serrano</example>
        [HttpGet("ChiliPeppers")]
        public IActionResult GetChiliSHU([FromQuery] string Ingredients)
        {

            if (string.IsNullOrWhiteSpace(Ingredients))
            {
                return BadRequest(new { Error = "No ingredients provided" });
            }
            // Step 2: Split input into a list and trim spaces
            var chiliList = Ingredients.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(chili => chili.Trim());

            // Step 3: Validate chili names
            var invalidChilies = chiliList.Where(chili => !myChillies.ContainsKey(chili)).ToList();
            if (invalidChilies.Any())
            {
                return BadRequest(new { Error = "Invalid chili names", InvalidChilies = invalidChilies });
            }

            // Step 4: Calculate total SHU
            int totalSHU = chiliList.Sum(chili => myChillies[chili]);

            return Ok(totalSHU);

        }
    }
}
