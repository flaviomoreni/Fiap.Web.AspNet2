using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Fiap.Web.AspNet2.Data
{
    public class DataContext : DbContext
    {

        public DbSet<RepresentanteModel> Representante {get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if ( optionsBuilder.IsConfigured == false  )
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("databaseUrl")); // Important !!!!
                optionsBuilder.EnableSensitiveDataLogging(); // Log
                optionsBuilder.LogTo(Console.Write); // Log
            }    
        }




        /*
        public DataContext( DbContextOptions options) : base(options)
        {
        }
        */
    }
}
