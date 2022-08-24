using Business.Bet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Bet.Request;
using Model.Bet.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGranTitan.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        [HttpPost]
        public BetInsertResponse Insert([FromBody] BetInsertRequest request)
        {
            return BetBL.Insert(request);
        }
    }
}
