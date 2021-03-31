using System;
using System.Text.Json.Serialization;

namespace ListaContatos.Models
{
    public interface IContato
    {
        [JsonIgnore]
        int Id { get; }
        string Nome { get; set; }
        string Telefone { get; set; }
        string Email { get; set; }
        int Idade { get; set; }
        DateTime DataCadastro { get; }
    }
}