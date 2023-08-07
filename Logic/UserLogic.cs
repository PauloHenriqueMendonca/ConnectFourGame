using ConnectFourGame.DB;
using ConnectFourGame.Models;
using ConnectFourGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectFourGame.Logic
{
    public class UserLogic
    {
        private UserDB DB = new UserDB();

        public List<User> GetMany(string email)
        {
            //fazer validacao necessaria para pegar um registro

            //chamar o DB para pegar o registro
            return DB.GetMany(email);
        }

        public User Get(string userName)
        {
            //chamar o DB para pegar o registro
            return DB.Get(userName);
        }

        public int Insert(UserVM model)
        {
            //fazer validacao necessaria para pegar um registro
            var user = DB.Get(model.Username);
            //Verificar se o novo usuario que esta sendo cadastrado ja existe antes 

            if(user == null)
            {
                //Validar se as senhas batem
                if(model.PasswordConfirmation == model.PasswordConfirmation)
                {
                    //criar modelo  
                    var u = new User();
                    u.Username = model.Username;
                    u.Password = model.Password;
                    u.Email = model.Email;

                    DB.Insert(u);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(model.Password), "Passwords must match!");
                }
            }
            
            //chamar o DB para inserir o registro
            return DB.Insert(user);
        }

        public int Update(string userName, string email, string confirmEmail, string password, string confirmPassword)
        {
            //pegar usuario baseado no filtro
            var model = DB.Get(userName);

            //fazer validacao necessaria para pegar um registro
            //Valida se os emails batem
            //Valida se as senhas batem


            //atualizar modelo
            model.Username = userName;
            model.Email = email;
            model.Password = password;

            //chamar o DB para atualizar o registro
            return DB.Update(model);
        }

        public bool Delete(int userId)
        {
            //fazer validacao necessaria para pegar um registro

            //chamar o DB para deletar o registro
            return DB.Delete(userId);
        }
    }
}