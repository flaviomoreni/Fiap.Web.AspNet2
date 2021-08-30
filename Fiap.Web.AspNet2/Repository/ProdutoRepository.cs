using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly DataContext context;

        public ProdutoRepository(DataContext _dataContext)
        {
            context = _dataContext;
        }

        public IList<ProdutoModel> FindAll()
        {
            using (context)
            {
                return context.Produto.ToList();
            }
        }

        public ProdutoModel FindById(int id)
        {
            using (context)
            {
                var produtoModel = context.Produto
                .Include(p => p.ProdutoLojas)
                    .ThenInclude(pl => pl.Loja)
                .SingleOrDefault(p => p.ProdutoId == id);

                return produtoModel;
            }
        }


        public int Insert(ProdutoModel produtoModel)
        {
            using (context)
            {
                context.Produto.Add(produtoModel);
                context.SaveChanges();
                return produtoModel.ProdutoId;
            }
        }

        public void Delete(int id)
        {
            using (context)
            {
                context.Produto.Remove(new ProdutoModel() { ProdutoId = id });
                context.SaveChanges();
            }
        }

        public void Update(ProdutoModel produtoModelNovo)
        {
            using (context)
            {
                var produtoAtual = FindById(produtoModelNovo.ProdutoId);
                produtoAtual.NomeProduto = produtoModelNovo.NomeProduto;
                produtoAtual.ProdutoLojas = produtoModelNovo.ProdutoLojas;

                context.Produto.Update(produtoAtual);
                context.SaveChanges();
            }

        }

    }
}
