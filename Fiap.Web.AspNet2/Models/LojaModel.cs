using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Fiap.Web.AspNet2.Models
{
    public class LojaModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LojaId { get; set; }

        public String NomeLoja { get; set; }


        //Navigation
        public ICollection<ProdutoLojaModel> ProdutoLojas { get; set; }

    }
}
