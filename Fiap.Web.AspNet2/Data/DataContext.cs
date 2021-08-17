using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Data
{
    public class DataContext : DbContext
    {

        public DbSet<RepresentanteModel> Representante {get; set;}


        public DataContext( DbContextOptions options) : base(options)
        {
        }
    }
}
