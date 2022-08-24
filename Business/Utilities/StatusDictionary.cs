using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class StatusDictionary
    {
        public static Dictionary<int, string> Status = new Dictionary<int, string>()
        {
            {1,"Creada" },
            {2,"Abierta"},
            {3,"Cerrada"}
        };
    }
}
