using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class LojaRepository : ILojaRepository
    {
        private readonly DataContext context;


        public LojaRepository(DataContext _dataContext)
        {
            context = _dataContext;
        }

        public IList<LojaModel> FindAll()
        {
            return context.Loja.ToList();
        }

        public LojaModel FindById(int id)
        {
            //var lojaModel = context.Loja.Find(id);
            var lojaModel = context.Loja
                .Include(l => l.ProdutoLojas)
                    .ThenInclude( pl => pl.Produto )
                .SingleOrDefault( l => l.LojaId == id );

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
