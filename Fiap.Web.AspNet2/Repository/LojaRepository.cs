using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class LojaRepository
    {
        private readonly DataContext context;


        public LojaRepository()
        {
            context = new DataContext();

        }

        public IList<LojaModel> FindAll()
        {
            return context.Loja.ToList();
        }

        public LojaModel FindById(int id)
        {
            var lojaModel = context.Loja.Find(id);

            return lojaModel;

        }

        public int Insert(LojaModel lojaModel)
        {
            context.Loja.Add(lojaModel);
            context.SaveChanges();
            return lojaModel.LojaId;
        }

        public void Delete(int id)
        {
            context.Loja.Remove(new LojaModel() { LojaId = id });
            context.SaveChanges();
        }

        public void Update(LojaModel lojaModel)
        {
            context.Loja.Update(lojaModel);
            context.SaveChanges();
        }

    }
}
