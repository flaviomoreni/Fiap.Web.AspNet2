using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext context;

        public ClienteRepository(DataContext _dataContext)
        {
            context = _dataContext;
        }

        public IList<ClienteModel> FindAll()
        {
            using (context)
            {
                return context.Cliente.ToList();
            }
        }

        public ClienteModel FindById(int id)
        {
            using( context ) { 

                var clienteModel = context.Cliente
                        .Include(c => c.Representante)
                        .SingleOrDefault(c => c.ClienteId == id);

                return clienteModel;
            }

        }

        public int Insert(ClienteModel clienteModel)
        {
            using (context) { 
                context.Cliente.Add(clienteModel);
                context.SaveChanges();
                return clienteModel.ClienteId;
            }
        }

        public void Delete(int id)
        {
            using (context)
            {
                context.Cliente.Remove(new ClienteModel() { ClienteId = id });
                context.SaveChanges();
            }
        }

        public void Update(ClienteModel clienteModel)
        {
            using (context)
            {
                context.Cliente.Update(clienteModel);
                context.SaveChanges();
            }
        }

    }
}
