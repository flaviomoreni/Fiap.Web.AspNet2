using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{

    [Index(nameof(ProdutoId),nameof(LojaId), IsUnique = true)]
    public class ProdutoLojaModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoLojaId { get; set; }

        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public ProdutoModel Produto { get; set; }

        public int LojaId { get; set; }
        [ForeignKey("LojaId")]
        public LojaModel Loja { get; set; }


    }
}
