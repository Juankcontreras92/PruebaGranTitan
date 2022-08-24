using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Bet.Request
{
    public class BetInsertRequest
    {
        public int RouletteId { get; set; }
        public int Number { get; set; }
        public string Color { get; set; }
        public decimal Amount { get; set; }
    }
}
