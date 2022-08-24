using Model.Base;
using Model.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Roulette.Response
{
    public class RouletteCloseResponse : BaseResponse
    {
        public string ColorWinner { get; set; }
        public int WinnerNumber { get; set; }
        public List<BetEntity> LtsBets { get; set; }
    }
}
