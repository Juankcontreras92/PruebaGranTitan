using Business.Utilities;
using Data.DAModel;
using Data.DataAccess;
using Model.Bet;
using Model.Roulette;
using Model.Roulette.Request;
using Model.Roulette.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Roulette
{
    public class RouletteBL
    {
        public static RouletteInsertResponse Insert()
        {
            RouletteInsertResponse response = new() { ReturnCode = "0" };
            try
            {
                int rouletteId = RouletteDAL.InsertCommand();
                response.RouletteId = rouletteId;
                response.ReturnCode = "100";
                response.Message = string.Format("La ruleta ha sido creada correctamente con el id {0}", rouletteId);
            }
            catch(Exception)
            {
                response.ReturnCode = "0";
                response.Message = "Ocurrió un error intentando crear una nueva ruleta";
            }
            return response;
        }
        public static RouletteOpenResponse OpenRoulette(RouletteOpenRequest request)
        {
            RouletteOpenResponse response = new() { ReturnCode = "0"};
            try
            {
                if (request.RouletteId > 0)
                {
                    bool opened = RouletteDAL.OpenRoulette(request.RouletteId);
                    response = ReturnResponseOpenRoulette(opened);
                }
                else
                {
                    response.Message = "El campo RouletteId es requerido para la operación";
                }
            }
            catch (Exception)
            {                
                response.Message = "Ocurrió un error intentando abrir la ruleta";
            }
            return response;
        }
        public static RouletteCloseResponse CloseRoulette(RouletteCloseRequest request)
        {
            RouletteCloseResponse response = new() { ReturnCode = "0" };
            try
            {
                if (request.RouletteId > 0)
                {
                    response = SelectWinner(request);
                }
                else
                {
                    response.Message = "El campo RouletteId es requerido para la operación";
                }
            }
            catch (Exception)
            {
                response.Message = "Ocurrió un error intentando cerrar la ruleta";
            }
            return response;
        }

        public static RouletteSelectResponse SelectAllRoulettes()
        {
            RouletteSelectResponse response = new() { ReturnCode = "0" };
            try
            {
                response.ListRoulettes = MappingToRouletteEntity(RouletteDAL.SelectCommand());
                response.ReturnCode = "100";
                response.Message = "Las ruletas fueron listadas correctamente";
            }
            catch (Exception)
            {
                response.Message = "Ocurrió un error al seleccionar todas las ruletas";
            }
            return response;
        }
        private static List<RouletteEntity> MappingToRouletteEntity(List<RouletteDAM> ltsRoulettes)
        {
            return ltsRoulettes.ConvertAll(x => new RouletteEntity()
            {
                CloseDate = x.CLOSE_DATE,
                CreationDate =x.CREATION_DATE,
                OpenDate =x.OPEN_DATE,
                RouletteId =x.ID,
                Status = StatusDictionary.Status.Where(y => y.Key == x.STATUS_ID).FirstOrDefault().Value
            });
        }

        private static RouletteCloseResponse SelectWinner(RouletteCloseRequest request)
        {
            RouletteCloseResponse response = new();
            int winnerNumber = GenerateWinnerNumber(out string color);            
            if (RouletteDAL.CloseRoulette(request.RouletteId))
            {
                response.ColorWinner = color;
                response.WinnerNumber = winnerNumber;
                response.LtsBets = CalculateEarnedMoney(request, winnerNumber, color);
                WinnerDAL.InsertCommand(new WinnerDAM() { COLOR = color, NUMBER = winnerNumber, ROULETTE_ID = request.RouletteId });
            }
            else
            {
                response.ReturnCode = "0";
                response.Message = "La ruleta no existe o no esta abierta";
            }
            
            return response;
        }
        private static List<BetEntity> CalculateEarnedMoney(RouletteCloseRequest request, int winnerNumber, string colorWinner)
        {
            List<BetEntity> ltsBetsEntity = new();
            List<BetDAM> ltsBets = BetDAL.SelectCommand(request.RouletteId);
            foreach(var item in ltsBets)
            {
                var bet =new BetEntity()
                {
                    Amount = item.AMOUNT,
                    Color = item.COLOR,
                    Number = item.NUMBER,
                    EarnedMoney = item.NUMBER == winnerNumber ? item.AMOUNT * 5 : 0 +
                    item.COLOR.ToUpper() == colorWinner.ToUpper() ? item.AMOUNT * (decimal)1.8 : 0,
                    IsWinner = item.NUMBER == winnerNumber || item.COLOR.ToUpper() == colorWinner.ToUpper()
                };
                ltsBetsEntity.Add(bet);
            }
            return ltsBetsEntity;
        }
        private static int GenerateWinnerNumber(out string color)
        {
            Random random = new();
            int winnerNumber = random.Next(0, 36);
            if (winnerNumber > 0)
                color = ReturnWinnerColor(winnerNumber);
            else
                color = string.Empty;
            return winnerNumber;
        }
        private static string ReturnWinnerColor(int winnerNumber)
        {
            if (winnerNumber % 2 == 0)
            {
                return "Rojo";
            }
            else
            {
                return "Negro";
            }
        }
        private static RouletteOpenResponse ReturnResponseOpenRoulette(bool opened)
        {
            RouletteOpenResponse response = new() { ReturnCode = "0" };
            if (opened)
            {
                response.ReturnCode = "100";
                response.Message = "La ruleta ha sido abierta correctamente";
            }
            else
            {
                response.Message = "La ruleta no puede ser abierta en este momento";
            }
            return response;

        }
    }
}
