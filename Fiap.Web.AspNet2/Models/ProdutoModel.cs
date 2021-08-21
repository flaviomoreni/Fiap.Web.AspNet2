using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Models
{
    public class ProdutoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        public String NomeProduto { get; set; }


        //Navigation
        public ICollection<ProdutoLojaModel> ProdutoLojas { get; set; }

    }
}
