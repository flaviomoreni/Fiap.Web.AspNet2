using Fiap.Web.AspNet2.Models;
using System;
using System.Collections.Generic;


namespace Fiap.Web.AspNet2.Repository
{
    public class ClienteRepository
    {

        //private readonly Object context;
        private IList<ClienteModel> listaClientes;

        public ClienteRepository()
        {
            // context = new Context;
            listaClientes = new List<ClienteModel>();
            listaClientes.Add(new ClienteModel(1, "Flávio", "flavio@email.com"));
            listaClientes.Add(new ClienteModel(2, "Eduardo", "eduardo@email.com"));
            listaClientes.Add(new ClienteModel(3, "Moreni", "moreni@email.com"));
        }

        public IList<ClienteModel> FindAll()
        {
            Console.WriteLine($"Cliente repository - FindAll");
            return listaClientes;
        }

        public ClienteModel FindById(int id)
        {
            Console.WriteLine($"Cliente repository - FindById Produto: {id}");

            if ( id > listaClientes.Count )
            {
                throw new Exception("Cliente não encontrado");
            } else
            {
                return listaClientes[id - 1];
            }

        }

        public int Insert(ClienteModel clienteModel)
        {
            Console.WriteLine($"Cliente repository - Insert Produto: {clienteModel.Nome}");

            listaClientes.Add(clienteModel);
            return new Random().Next();
        }

        public void Delete(int id)
        {
            Console.WriteLine($"Cliente repository - Delete Id: {id}");
            // commando entity
        }

        public void Update(ClienteModel clienteModel)
        {
            Console.WriteLine($"Cliente repository - Update Produto: {clienteModel.Nome}");
        }

    }
}
