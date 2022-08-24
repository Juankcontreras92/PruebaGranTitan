using Data.DAModel;
using Data.DataAccess;
using Model.Bet.Request;
using Model.Bet.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Bet
{
    public class BetBL
    {
        public static BetInsertResponse Insert(BetInsertRequest request)
        {
            BetInsertResponse response = new() { ReturnCode = "0" };
            try
            {
                response = ValidateRequest(request);
                if (response.ReturnCode.Equals("100"))
                {
                    bool inserted = BetDAL.InsertCommand(MappingToBetDAM(request));
                    response.ReturnCode = inserted ? "100":"0";
                    response.Message = inserted ? "La apuesta ha sido creada correctamente" : "La ruleta no existe o no esta abierta";
                }

            }
            catch (Exception e)
            {
                response.Message = "Ocurrió un error intentando crear una nueva ruleta";
            }
            return response;
        }
        private static BetInsertResponse ValidateRequest(BetInsertRequest request)
        {
            BetInsertResponse response = new() { ReturnCode = "100" };
            if(!(request.RouletteId > 0))
            {
                response.ReturnCode = "0";
                response.Message = "Ingrese el id de una ruleta";
            }
            if (request.Amount > 10000 || request.Amount <=0)
            {
                response.ReturnCode = "0";
                response.Message = "Ingrese un monto mayor a Cero y menor a 10.000";
            }
            if (request.Number > 36 || request.Number < 0)
            {
                response.ReturnCode = "0";
                response.Message = "Ingrese un número de 0 a 36";
            }
            if (!(request.Color.ToUpper().Equals("ROJO")) && !(request.Color.ToUpper().Equals("NEGRO")))
            {
                response.ReturnCode = "0";
                response.Message = "Ingrese un color valido: Rojo o Negro";
            }
            return response;
        }
        private static BetDAM MappingToBetDAM(BetInsertRequest request)
        {
            BetDAM map = new() { AMOUNT = request.Amount,
                COLOR = request.Color,
                NUMBER = request.Number,
                ROULETTE_ID = request.RouletteId };
            return map;
        }
    }
}
