using Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Roulette.Response
{
    public class RouletteSelectResponse : BaseResponse
    {
        public List<RouletteEntity> ListRoulettes { get; set; }
    }
}
