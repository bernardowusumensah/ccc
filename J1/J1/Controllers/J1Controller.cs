using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace J1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {

        /// <summary>
        /// This method calculates the score of a player in a game called DeliveDroid
        /// </summary>
        /// <param name="collisions"></param>
        /// <param name="deliveries"></param>
        /// <example> 
        /// POST /api/J1/Delivedroid
        /// HEADERS: Content-Type: application/x-www-form-urlencoded
        /// FORM DATA: "collisions={collisions}&deliveries={deliveries}"
        /// -> A post method with a form encoded request body. 
        /// Body Content: collisions: {collisions} deliveries: {deliveries}
        /// </example>
        ///  <returns>
        ///  An HTTP response that calculates the score of a player in a game called DeliveDroid 
        /// s</returns>

        [HttpPost(template: "Delivedroid")]
        [Consumes("application/x-www-form-urlencoded")]
        public string Delivedroid([FromForm] int collisions, [FromForm] int deliveries)
        {
            int noOfpackages = deliveries * 50;
            int noOfObstacles = collisions * 10;
            int score = noOfpackages - noOfObstacles;

            if (noOfpackages > noOfObstacles)
            {
                score += 500;
            }

            return score.ToString();
        }
    }
}
