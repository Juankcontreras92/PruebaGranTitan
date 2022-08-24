using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Bet
{
    public class BetEntity
    {
        public int Number { get; set; }
        public string Color { get; set; }
        public decimal Amount { get; set; }
        public decimal EarnedMoney { get; set; }
        public bool IsWinner { get; set; }
    }
}
