using ConnectFourGame.DB;
using ConnectFourGame.Models;
using ConnectFourGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectFourGame.Logic
{
    public class GameLogic
    {
        private GameDB DB = new GameDB();

        public Game Get(int gameId)
        {
            //chamar o DB para pegar o registro
            return DB.Get(gameId);
        }
        public List<Game> GetMany(int userId)
        {
            //fazer validacao necessaria para pegar um registro

            //chamar o DB para pegar o registro
            return DB.GetMany(userId);
        }

        public int Insert(Game model)
        {
            //fazer validacao necessaria para pegar um registro
            var game = DB.Get(model.GameId);
            //Verificar se o novo usuario que esta sendo cadastrado ja existe antes 
            var games = DB.GetMany(model.UserId);
            if (game == null)
            {
                var g = new Game();
                g.GameId = model.GameId;
                g.UserId = model.UserId;
                g.Date = DateTime.Now;
                g.Winner = model.Winner;
                g.QuantMoves = model.QuantMoves;

                DB.Insert(g);
            }

            //chamar o DB para inserir o registro
            return 0;
        }

        public int Update(int gameId)
        {
            //pegar usuario baseado no filtro
            var model = DB.Get(gameId);

            //fazer validacao necessaria para pegar um registro
            //Valida se os emails batem
            //Valida se as senhas batem


            //atualizar modelo
            //model.Username = userName;
            //model.Email = email;
            //model.Password = password;

            //chamar o DB para atualizar o registro
            return DB.Update(model);
        }

        public bool Delete(int gameId)
        {
            var game = DB.Delete(gameId);
            //fazer validacao necessaria para pegar um registro

            //chamar o DB para deletar o registro
            return DB.Delete(gameId);
        }
    }
}