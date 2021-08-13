using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Models
{
    public class ClienteModel
    {

        public ClienteModel() { }

        public ClienteModel(int clienteId, String nome, String email)
        {
            this.ClienteId = clienteId;
            this.Nome = nome;
            this.Email = email;
        }

        public ClienteModel(int clienteId, String nome, String email, DateTime dataNacimento, String observacao)
        {
            this.ClienteId = clienteId;
            this.Nome = nome;
            this.Email = email;
            this.DataNascimento = dataNacimento;
            this.Observacao = observacao;
        }


        public int ClienteId { get; set; }

        public String Nome { get; set; }

        public String Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public String Observacao { get; set; }

    }
}
