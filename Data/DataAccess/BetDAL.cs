using Data.Connection;
using Data.DAModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class BetDAL
    {
        public static bool InsertCommand(BetDAM bet)
        {
            var service = new DataModelService();
            int value = service.ExecuteNonQueryModel<object>("SPR_BET_InsertCommand", bet);
            return value > 0;
        }

        public static List<BetDAM> SelectCommand(int rouletteId)
        {
            var service = new DataModelService();
            List<BetDAM> ltsBets = service.GetListByParameter<BetDAM, object>("SPR_BET_SelectCommand", new { @ROULETTE_ID = rouletteId });
            return ltsBets;
        }
    }
}
