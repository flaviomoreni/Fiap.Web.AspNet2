using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{
    //[Table("TB_Cidade")]
    [Microsoft.EntityFrameworkCore.Index(nameof(NomeCidade), nameof(Estado))]
    public class CidadeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("Cod_Cidade")]
        public int CidadeId { get; set; }

        //[Column("Nom_Cidade")]
        [Required]
        [MaxLength(70)]
        [MinLength(2)]
        public String NomeCidade { get; set; }

        //[Column("Qtde_Habits")]
        public int QuantidadeHabitantes { get; set; }

        //[Column("UF")]
        [MaxLength(2)]
        public String Estado { get; set; }

        [NotMapped]
        public String PrefeitoNome { get; set; }

    }
}
