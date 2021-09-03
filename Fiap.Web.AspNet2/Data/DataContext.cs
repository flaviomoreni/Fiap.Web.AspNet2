using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Fiap.Web.AspNet2.ViewModel;

namespace Fiap.Web.AspNet2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DataContext()
        {
        }


        public DbSet<RepresentanteModel> Representante {get; set;}
        public DbSet<CidadeModel> Cidade { get; set; }
        public DbSet<PaisModel> Pais { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<LojaModel> Loja { get; set; }
        public DbSet<ProdutoLojaModel> ProdutoLoja { get; set; }
        




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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<PaisModel>().ToTable("TB_Pais");
            modelBuilder.Entity<PaisModel>().HasKey(p => p.PaisId);
            modelBuilder.Entity<PaisModel>().Property(p => p.PaisId)
                    //.HasColumnName("CD_Pais")
                    .ValueGeneratedOnAdd();

            modelBuilder.Entity<PaisModel>().Property(p => p.NomePais)
                //.HasColumnName("NM_Pais")
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<PaisModel>().Property(p => p.Continente)
                .HasMaxLength(30);

            modelBuilder.Entity<PaisModel>().HasIndex(p => p.NomePais);

            



            modelBuilder.Entity<CidadeModel>().HasData(
                new CidadeModel()
                {
                    CidadeId = 1,
                    NomeCidade = "São Paulo",
                    Estado = "SP",
                    QuantidadeHabitantes = 11
                },
                new CidadeModel()
                {
                    CidadeId = 2,
                    NomeCidade = "Rio de Janeiro",
                    Estado = "RJ",
                    QuantidadeHabitantes = 5
                }
            );


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Fiap.Web.AspNet2.ViewModel.FornecedorViewModel> FornecedorViewModel { get; set; }







        /*
        public DataContext( DbContextOptions options) : base(options)
        {
        }
        */
    }
}
