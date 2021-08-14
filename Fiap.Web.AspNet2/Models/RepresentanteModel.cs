using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Models
{
    public class RepresentanteModel
    {

        public int RepresentanteId { get; set; }

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
