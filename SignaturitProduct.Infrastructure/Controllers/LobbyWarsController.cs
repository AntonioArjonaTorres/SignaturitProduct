using Microsoft.AspNetCore.Mvc;
using SignaturitProduct.Application;
using SignaturitProduct.Domain;

namespace SignaturitProduct.Infrastructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LobbyWarsController : ControllerBase
    {
        ApiResponse apiResponse = new ApiResponse();

        // POST: LobbyWars/WhoWins
        [HttpPost("WhoWins", Name = "Who wins")]
        public ActionResult WhoWins(ApiRequest apiRequest)
        {
            TrialBattle trialBattle = new TrialBattle(apiRequest);
            this.apiResponse = trialBattle.prepareBattle();

            if (this.apiResponse.Error) return BadRequest(this.apiResponse.ResponseText);
            else return Ok(this.apiResponse.ResponseText);
        }

        // POST: LobbyWars/NecessaryToWin
        [HttpPost("NecessaryToWin", Name = "Necessary to win")]
        public ActionResult NecessaryToWin(ApiRequest apiRequest)
        {
            TrialHowToWin trialHowToWin = new TrialHowToWin(apiRequest);
            this.apiResponse = trialHowToWin.getNecessaryToWin();

            if (this.apiResponse.Error) return BadRequest(this.apiResponse.ResponseText);
            else return Ok(this.apiResponse.ResponseText);
        }
    }
}