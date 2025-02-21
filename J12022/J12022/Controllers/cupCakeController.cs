using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace J12022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cupCakeController : ControllerBase
    {
        [HttpPost("calculate")]
        public IActionResult CalculateCupcakes([FromBody] CupcakeRequest request)
        {
            if (request == null || request.RegularBoxes < 0 || request.SmallBoxes < 0)
            {
                return BadRequest("Invalid input");
            }

            // Step 2: Calculate total cupcakes
            int totalCupcakes = (request.RegularBoxes * 8) + (request.SmallBoxes * 3);

            // Step 3: Calculate leftover cupcakes
            int leftover = totalCupcakes - 28;

            // Step 4: Output the result
            return Ok(new { LeftoverCupcakes = leftover });
        }
    }

    public class CupcakeRequest
    {
        public int RegularBoxes { get; set; }
        public int SmallBoxes { get; set; }
    }
}
