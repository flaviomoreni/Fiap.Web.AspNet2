using AutoMapper;
using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.Repository.Interface;
using Fiap.Web.AspNet2.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();

            var connectionString = Configuration.GetConnectionString("databaseUrl");
            services.AddDbContext<DataContext>(option => option.UseSqlServer(connectionString)
                                                         .EnableSensitiveDataLogging()
                                                         .LogTo(Console.Write) );

            var mapperConfig = new AutoMapper.MapperConfiguration(
                c =>
                {
                    c.CreateMap<ClienteViewModel, ClienteModel>();
                    
                    c.CreateMap<ClienteModel, ClienteViewModel>();
                    
                    c.CreateMap<RepresentanteViewModel, RepresentanteModel>();
                    
                    //c.CreateMap<RepresentanteModel, RepresentanteViewModel>().ForMember(
                    //    v => v.Clientes, m => m.MapFrom(x => x.Clientes)
                    //);

                    c.CreateMap<RepresentanteModel, RepresentanteViewModel>()
                        .ForMember(v => v.RepresentanteId, m => m.MapFrom(x => x.RepresentanteId))
                        .ForMember(v => v.NomeRepresentante , m => m.MapFrom(x => x.RepresentanteId))
                        .ForMember(v => v.Clientes, m => m.MapFrom(x => x.Clientes) );


                    c.CreateMap<IList<RepresentanteViewModel>, IList<RepresentanteModel>>();

                    c.CreateMap<ProdutoLojaViewModel, ProdutoModel>();
                }
            );
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ILojaRepository, LojaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
