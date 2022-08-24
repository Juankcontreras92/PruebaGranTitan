using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Roulette
{
    public class RouletteEntity
    {
        public int RouletteId { get; set; }
        public string CreationDate { get; set; }
        public string OpenDate { get; set; }
        public string CloseDate { get; set; }
        public string Status { get; set; }
    }
}
