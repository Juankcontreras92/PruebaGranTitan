using Data.Connection;
using Data.DAModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class WinnerDAL
    {
        public static bool InsertCommand(WinnerDAM winner)
        {
            var service = new DataModelService();
            int value = service.ExecuteNonQueryModel<object>("SPR_WINNER_InsertCommand", winner);
            return value > 0;
        }
    }
}
