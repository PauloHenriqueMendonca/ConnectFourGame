using ConnectFourGame.Models;
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

        private void SaveToDB(User model)
        {
            //connectar toDB para pegar lista de registros
            ConnectDB();

            //Antes de salvar preciso de verificar se o usuario ja existe
            //var userExists = model.FirstOrDefault(uexists => uexists.Username == usuario);

            //if (userExists != null)
            //{
            //    ViewBag.ErrorMessage = "Usuario ja existe, favor tente outro usuario!";
            //    return View("Cadastro");
            //}
            //else
            //{
            //    var ultimoUserID = model.Max(user => user.UserId);
            //    ultimoUserID++;

            //    //adicionar registro na lista Json
            //    var u = new User();
            //    u.UserId = ultimoUserID;
            //    u.Username = usuario;
            //    u.Email = email;
            //    u.Password = senha;

            //    usuarios.Add(u);
            //}

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

        public User Get(string userName)
        {
            //chamar connect DB para pegar lista de registros
            ConnectDB();
            //filtrar baseado nos parametros da funcao
            //var userExists = users.FirstOrDefault(uexists => uexists.Username == usuario);

            return null;
        }

        public int Insert(User model)
        {
            //Chamar o DB
            ConnectDB();
            // Gerar novo Id - atualizar registro para ter um Id valido

            //adicionar o registro na lista de itens


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