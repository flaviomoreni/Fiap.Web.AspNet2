using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Repository.Interface
{
    public interface ILojaRepository
    {
        public IList<LojaModel> FindAll();

        public LojaModel FindById(int id);

        public int Insert(LojaModel lojaModel);

        public void Delete(int id);

        public void Update(LojaModel lojaModel);
    }
}
