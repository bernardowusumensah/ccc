using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace J32022.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class TuningController : ControllerBase
    {
        [HttpPost("format")]
        public IActionResult FormatTuningInstructions([FromBody] TuningRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Instructions))
                return BadRequest("Instructions cannot be empty");

            string pattern = @"([A-Z]+)([+-])(\d+)";
            var matches = Regex.Matches(request.Instructions, pattern);
            var formattedInstructions = new List<string>();

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    string letters = match.Groups[1].Value;
                    string action = match.Groups[2].Value == "+" ? "tighten" : "loosen";
                    string turns = match.Groups[3].Value;

                    formattedInstructions.Add($"{letters} {action} {turns}");
                }
            }

            return Ok(formattedInstructions);
        }
    }

    public class TuningRequest
    {
        public required string Instructions { get; set; }
    }



}
