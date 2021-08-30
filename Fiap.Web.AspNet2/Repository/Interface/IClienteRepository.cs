using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Repository.Interface
{
    public interface IClienteRepository
    {
        public IList<ClienteModel> FindAll();

        public ClienteModel FindById(int id);

        public int Insert(ClienteModel clienteModel);

        public void Delete(int id);

        public void Update(ClienteModel clienteModel);

    }
}
