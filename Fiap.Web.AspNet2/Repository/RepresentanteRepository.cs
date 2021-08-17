using Fiap.Web.AspNet2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Repository
{
    public class RepresentanteRepository
    {

        private readonly IList<RepresentanteModel> listaRepresentantes;

        public RepresentanteRepository()
        {
            listaRepresentantes = new List<RepresentanteModel>()
            {
                new RepresentanteModel(1,"Ana"),
                new RepresentanteModel(2,"Ricardo"),
                new RepresentanteModel(3,"Karen"),
                new RepresentanteModel(4,"Filipe")
            };
        }


        public IList<RepresentanteModel> FindAll()
        {
            Console.WriteLine($"RepresentanteRepository - FindAll");
            return listaRepresentantes;
        }


        public RepresentanteModel FindById(int id)
        {
            Console.WriteLine($"Representante repository - FindById Produto: {id}");

            if (id > listaRepresentantes.Count)
            {
                throw new Exception("Representante não encontrado");
            }
            else
            {
                return listaRepresentantes[id - 1];
            }

        }




    }
}
