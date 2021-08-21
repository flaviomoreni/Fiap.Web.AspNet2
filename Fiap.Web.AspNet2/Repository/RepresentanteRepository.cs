using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class RepresentanteRepository
    {

        private readonly DataContext context;

        public RepresentanteRepository()
        {
            context = new DataContext();
        }


        public IList<RepresentanteModel> FindAll()
        {
            var lista = context.Representante.ToList();
            //var lista = context.Representante.Where( r => r.NomeRepresentante.Contains("a") ).ToList();
            return lista;
        }


        public RepresentanteModel FindById(int id)
        {
            var representante = context.Representante.Find(id);
            return representante;
        }


        public RepresentanteModel FindByIdWithClientes(int id)
        {
            var representante = 
                context.Representante
                    .Include( r => r.Clientes )
                    .SingleOrDefault( r => r.RepresentanteId == id );

            return representante;
        }



        public void Insert(RepresentanteModel representanteModel)
        {
            context.Representante.Add(representanteModel);
            context.SaveChanges();
        } 

        public void Update(RepresentanteModel representanteModel)
        {
            context.Representante.Update(representanteModel);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            RepresentanteModel representanteModel = new RepresentanteModel();
            representanteModel.RepresentanteId = id;

            Delete(representanteModel);
        }

        public void Delete(RepresentanteModel representanteModel)
        {
            context.Representante.Remove(representanteModel);
            context.SaveChanges();
        }

    }
}
