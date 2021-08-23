using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.ViewModel
{
    public class ProdutoLojaViewModel
    {

        public ProdutoModel Produto { get; set; }

        public ICollection<int> LojaId { get; set; }

        //public ICollection<LojaModel> Lojas { get; set; }

    }
}
