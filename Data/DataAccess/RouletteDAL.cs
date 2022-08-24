using Data.Connection;
using Data.DAModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class RouletteDAL
    {
        public static int InsertCommand()
        {
            var parameter = new { };
            var service = new DataModelService();
            RouletteDAM roulette = service.GetListByParameter<RouletteDAM, object>("SPR_ROULETTE_InsertCommand", parameter).FirstOrDefault();
            return roulette.ID;
        }
        public static bool OpenRoulette(int id)
        {
            var parameter = new { ID = id};
            var service = new DataModelService();
            int value = service.ExecuteNonQueryModel<object>("SPR_ROULETTE_Open", parameter);
            return value > 0;
        }
        public static bool CloseRoulette(int id)
        {
            var parameter = new { ID = id };
            var service = new DataModelService();
            int value = service.ExecuteNonQueryModel<object>("SPR_ROULETTE_Close", parameter);
            return value > 0;
        }
        public static List<RouletteDAM> SelectCommand()
        {
            var service = new DataModelService();
            List<RouletteDAM> ltsRoulettes = service.GetListByParameter<RouletteDAM, object>("SPR_ROULETTE_SelectCommand", new {});
            return ltsRoulettes;
        }
    }
}
