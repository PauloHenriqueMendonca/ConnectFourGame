﻿using ConnectFourGame.Models;
using ConnectFourGame.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ConnectFourGame.DB
{
    public class UserDB
    {
        private string JsonPath = HttpContext.Current.Server.MapPath("~/Json/User.json");

        private List<User> ConnectDB()
        {
            //connectar no json
            List<User> users = new List<User>();
            //Retornar lista de registros
            using (StreamReader reader = new StreamReader(JsonPath))
            {
                var json = reader.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }

            return users;
        }

        private void SaveToDB(List<User> model)
        {
            //atualizar Json
            var jsonString = JsonConvert.SerializeObject(model, Formatting.Indented);
            System.IO.File.WriteAllText(JsonPath, jsonString);
        }

        private int GetMaxId()
        {
            // pegar lista de registros 

            //selecionar maior Id dentro dos registros

            return 0;
        }

        public List<User> GetMany(string email)
        {
            //chamar connect DB para pegar lista de registros

            //filtrar baseado nos parametros da funcao


            return Enumerable.Empty<User>().ToList();
        }

        public User Get(string username)
        {
            //chamar connect DB para pegar lista de registros
            var person = ConnectDB();
            //filtrar baseado nos parametros da funcao
            var userExists = person.FirstOrDefault(p => p.Username == username);

            return userExists;
        }

        public int Insert(User model)
        {
            //Chamar o DB
            var users = ConnectDB();
            // Gerar novo Id - atualizar registro para ter um Id valido
            var lastUserId = 1;
            
            if(users.Count > 0)
            {
                lastUserId = users.Max(u => u.UserId);
                lastUserId++;
            }

            model.UserId = lastUserId;
            users.Add(model);
            //adicionar o registro na lista de itens
            SaveToDB(users);

            return model.UserId;
        }

        public int Update(User model)
        {
            //remover registro da lista baseado no filtro


            //salvar o registro na lista de itens


            return model.UserId;
        }

        public bool Delete(int userId)
        {
            //connectar toDB para pegar lista de registros


            //remover registro da lista baseado no filtro

            // Retornar true or False se removeu

            return false;
        }


    }
}