using ConnectFourGame.Models;
using ConnectFourGame.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ConnectFourGame.DB
{
    public class GameDB
    {
        private string JsonPath = HttpContext.Current.Server.MapPath("~/Json/Game.json");

        private List<Game> ConnectDB()
        {
            //connectar no json
            List<Game> games = new List<Game>();
            //Retornar lista de registros
            using (StreamReader reader = new StreamReader(JsonPath))
            {
                var json = reader.ReadToEnd();
                games = JsonConvert.DeserializeObject<List<Game>>(json);
            }

            return games;
        }

        private void SaveToDB(List<Game> model)
        {
            //atualizar Json
            var jsonString = JsonConvert.SerializeObject(model, Formatting.Indented);
            System.IO.File.WriteAllText(JsonPath, jsonString);
        }

        public List<Game> GetMany(int userId)
        {
            //chamar connect DB para pegar lista de registros
            var games = ConnectDB();
            //filtrar baseado nos parametros da funcao
            var gamesPerUser = games.Where(g => g.UserId == userId);

            return gamesPerUser.ToList();
        }
        private int GetMaxId()
        {
            // pegar lista de registros 

            //selecionar maior Id dentro dos registros

            return 0;
        }


        public Game Get(int gameId)
        {
            //chamar connect DB para pegar lista de registros
            var game = ConnectDB();
            //filtrar baseado nos parametros da funcao
            var gameExists = game.FirstOrDefault(p => p.GameId == gameId);

            return gameExists;
        }

        public int Insert(Game model)
        {
            //Chamar o DB
            var games = ConnectDB();
            // Gerar novo Id - atualizar registro para ter um Id valido
            var lastGameId = 1;
            
            if(games.Count > 0)
            {
                lastGameId = games.Max(g => g.GameId);
                lastGameId++;
            }

            model.GameId = lastGameId;
            games.Add(model);
            //adicionar o registro na lista de itens
            SaveToDB(games);

            return model.GameId;
        }

        public int Update(Game model)
        {
            //remover registro da lista baseado no filtro


            //salvar o registro na lista de itens


            return model.UserId;
        }

        public bool Delete(int gameId)
        {
            //connectar toDB para pegar lista de registros
            var game = ConnectDB();

            //remover registro da lista baseado no filtro
            var gameDelete = game.FirstOrDefault(g => g.GameId == gameId);

            if (gameDelete != null)
            {
                game.Remove(gameDelete);
                SaveToDB(game);

                return true;
            }
            // Retornar true or False se removeu


            return false;
        }


    }
}