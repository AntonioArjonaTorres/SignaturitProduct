using Microsoft.AspNetCore.Mvc;

namespace SignaturitProduct.Infrastructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LobbyWarsController : ControllerBase
    {
        // POST: LobbyWars/WhoWins
        [HttpPost("WhoWins", Name = "Who wins")]
        public ActionResult WhoWins()
        {
            return Ok();
        }

        // POST: LobbyWars/NecessaryToWin
        [HttpPost("NecessaryToWin", Name = "Necessary to win")]
        public ActionResult NecessaryToWin()
        {
            return Ok();
        }
    }
}