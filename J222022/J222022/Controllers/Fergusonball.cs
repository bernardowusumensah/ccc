using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace J222022.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class FergusonballController : ControllerBase
    {
        [HttpPost("CalculateStars")]
        public IActionResult CalculateStars([FromBody] List<Player> players)
        {
            List<int> starRatings = players.Select(player => (player.Points * 5) - (player.Fouls * 3)).ToList();

            int qualifiedPlayers = starRatings.Count(rating => rating > 40);
            bool isGoldTeam = starRatings.All(rating => rating > 40);

            return Ok(isGoldTeam ? $"{qualifiedPlayers}+" : qualifiedPlayers.ToString());
        }
    }

    public class Player
    {
        public int Points { get; set; }
        public int Fouls { get; set; }
    }
}
