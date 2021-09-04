using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using LinqKit;
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
            return context.Cliente.ToList();
        }


        public IList<ClienteModel> FindByEmailAndRepresentante(string email, int idRepresentante)
        {

            var conditions = PredicateBuilder.New<ClienteModel>(true);

            if ( ! string.IsNullOrWhiteSpace(email) )
            {
                conditions = conditions.And(c => c.Email == email);
            }

            if ( idRepresentante != 0 )
            {
                conditions = conditions.And(c => c.RepresentanteId == idRepresentante);
            }

            var clientes = context.Cliente
                .Include(c => c.Representante)
                .Where(conditions)
                .ToList();

            /*
            var clientes = context.Cliente
                .Include( c => c.Representante )
                .Where( c => ( "" == email || c.Email == email ) && 
                             ( 0 == idRepresentante || c.RepresentanteId == idRepresentante) )
                .ToList();
            */

            return clientes;
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
