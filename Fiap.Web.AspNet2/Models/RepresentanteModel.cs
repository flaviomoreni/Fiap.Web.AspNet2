using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.Models
{
    //[Table("TB_REPRESENTANTE")]
    public class RepresentanteModel
    {

        [Key]
        //[Column("Cd_repre")]
        public int RepresentanteId { get; set; }

        //[Column("NomeRepresentante")]
        public String NomeRepresentante { get; set; }


        public RepresentanteModel()
        {
        }

        public RepresentanteModel(int representanteId, String nomeRepresentante)
        {
            RepresentanteId = representanteId;
            NomeRepresentante = nomeRepresentante;
        }
    }
}
