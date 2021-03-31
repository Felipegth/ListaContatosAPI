using ListaContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Repositories 
{
    public static class UserRepository
    {
        public static User Get(string username, string password) //Devolve simulando usuarios correspondente aos parametros da classe User.cs
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "angelito", Password = "04F66D16F352842802968B45EF5BC052BD2C306179A1C01B8E2E85F9F0F525D1", Role = "manager" }); // gerente
            users.Add(new User { Id = 2, Username = "felipe", Password = "2BD2D3A31934D76198ACC030CACA4C31965474FE5FA48F35FEF79D0FD74EE1B2", Role = "employee" }); // empregado
       
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}           //Simula como se estivesse indo em um banco de dados, mas está em memória
