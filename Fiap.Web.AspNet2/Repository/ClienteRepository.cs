using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class ClienteRepository
    {


        private readonly DataContext context;


        public ClienteRepository()
        {
            context = new DataContext();

        }

        public IList<ClienteModel> FindAll()
        {
            return context.Cliente.ToList();
        }

        public ClienteModel FindById(int id)
        {
            //var clienteModel = context.Cliente.Find(id);

            var clienteModel = context.Cliente
                    .Include(c => c.Representante)
                    .SingleOrDefault(c => c.ClienteId == id);

            return clienteModel;

        }

        public int Insert(ClienteModel clienteModel)
        {
            context.Cliente.Add(clienteModel);
            context.SaveChanges();
            return clienteModel.ClienteId;
        }

        public void Delete(int id)
        {
            context.Cliente.Remove(new ClienteModel() { ClienteId = id });
            context.SaveChanges();
        }

        public void Update(ClienteModel clienteModel)
        {
            context.Cliente.Update(clienteModel);
            context.SaveChanges();
        }

    }
}
