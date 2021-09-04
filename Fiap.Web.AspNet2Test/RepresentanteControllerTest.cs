using AutoMapper;
using Fiap.Web.AspNet2.Controllers;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Fiap.Web.AspNet2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fiap.Web.AspNet2Test
{
    public class RepresentanteControllerTest
    {
        
        // Lista de Representantes igual ao banco
        [Fact]
        public Task IndexReturnsViewResultWithListOfRepresentantes()
        {
            var repositoryMock = new Mock<IRepresentanteRepository>();
            repositoryMock.Setup(r => r.FindAll()).Returns(ListaRepresenantes3());

            var mapperConfig = new AutoMapper.MapperConfiguration(
                c =>
                {
                    //c.AddProfile(new AutoMapperProfile());
                    c.CreateMap<IList<RepresentanteViewModel>, IList<RepresentanteModel>>();
                }
            );
            IMapper mapper = mapperConfig.CreateMapper();

            var controller = new RepresentanteController(repositoryMock.Object , mapper);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<RepresentanteModel>>(viewResult.Model);

            Assert.Equal(3, model.Count());

            return Task.CompletedTask;
        }

        /*
        // Lista sem Representantes
        [Fact]
        public Task IndexReturnsViewResultWithZeroRepresentantes()
        {
            var repositoryMock = new Mock<IRepresentanteRepository>();
            repositoryMock.Setup(r => r.FindAll()).Returns( new List<RepresentanteModel>() );

            var controller = new RepresentanteController(repositoryMock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<RepresentanteModel>>(viewResult.Model);

            Assert.Empty(model);

            return Task.CompletedTask;
        }
        */
        

        private IList<RepresentanteModel> ListaRepresenantes3()
        {
            return new List<RepresentanteModel>()
            {
                new RepresentanteModel(1,"Flávio"),
                new RepresentanteModel(2,"Eduardo"),
                new RepresentanteModel(3,"Moreni"),
            };
        }
        


        // Lista com 1 representante


        // Lista com exception de banco de dados


    }
}
