using System;
using System.Text.Json.Serialization; // gera o token e codifica

namespace ListaContatos.Models
{
    public class Contato : IContato
    {
        public Contato() { }

        public Contato(int id, string nome, string telefone, string email, int idade)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Idade = idade;
            DataCadastro = DateTime.Now;
        }

        public Contato(int id, string nome, string telefone, string email, int idade, DateTime dtCadastro)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Idade = idade;
            DataCadastro = dtCadastro;
        }

        [JsonIgnore]
        public int Id { get; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public DateTime DataCadastro { get; private set; }
    }
}