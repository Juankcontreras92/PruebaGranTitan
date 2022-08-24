using Business.Roulette;
using Microsoft.AspNetCore.Mvc;
using Model.Roulette;
using Model.Roulette.Request;
using Model.Roulette.Response;

namespace PruebaGranTitan.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        [HttpPost]
        public RouletteInsertResponse Insert()
        {
            return RouletteBL.Insert();
        }
        [HttpPut]
        public RouletteOpenResponse Open([FromBody] RouletteOpenRequest request)
        {
            return RouletteBL.OpenRoulette(request);
        }
        [HttpPost]
        public RouletteCloseResponse Close([FromBody] RouletteCloseRequest request)
        {
            return RouletteBL.CloseRoulette(request);
        }
        [HttpGet]
        public RouletteSelectResponse Select()
        {
            return RouletteBL.SelectAllRoulettes();
        }
    }
}
