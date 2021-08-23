using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Repository
{
    public class ProdutoRepository
    {

        private readonly DataContext context;

        public ProdutoRepository()
        {
            context = new DataContext();
        }

        public IList<ProdutoModel> FindAll()
        {
            return context.Produto.ToList();
        }

        public ProdutoModel FindById(int id)
        {
            var produtoModel = context.Produto
                .Include(p => p.ProdutoLojas)
                    .ThenInclude ( pl => pl.Loja )
                .SingleOrDefault( p => p.ProdutoId == id);

            return produtoModel;
        }


        public int Insert(ProdutoModel produtoModel)
        {
            context.Produto.Add(produtoModel);
            context.SaveChanges();
            return produtoModel.ProdutoId;
        }

        public void Delete(int id)
        {
            context.Produto.Remove(new ProdutoModel() { ProdutoId = id });
            context.SaveChanges();
        }

        public void Update(ProdutoModel produtoModel)
        {
            context.Produto.Update(produtoModel);
            context.SaveChanges();
        }

    }
}
