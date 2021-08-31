//using Fiap.Web.AspNet2.Models;
using AutoMapper;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Fiap.Web.AspNet2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Controllers
{
    public class RepresentanteController : Controller
    {
        private readonly IRepresentanteRepository representanteRepository;
        private readonly IMapper mapper;

        public RepresentanteController( IRepresentanteRepository _representanteRepository, IMapper _mapper )
        {
            representanteRepository = _representanteRepository;
            mapper = _mapper;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var representantes = 
                mapper.Map<IList<RepresentanteViewModel>>(representanteRepository.FindAll());

            return View(representantes);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View(new RepresentanteViewModel());
        }

        [HttpPost]
        public IActionResult Novo(RepresentanteViewModel representanteVM)
        {
            var representanteModel = mapper.Map<RepresentanteModel>(representanteVM);

            representanteRepository.Insert(representanteModel);

            TempData["mensagemSucesso"] = $"Representante {representanteVM.NomeRepresentante} cadastrado com sucesso";
            return RedirectToAction("Index");
        }


        // Abrindo a tela de alteração
        [HttpGet]
        public IActionResult Alterar(int id)
        {
            var representanteModel = representanteRepository.FindByIdWithClientes(id);
            var representanteVM = mapper.Map<RepresentanteViewModel>(representanteModel);

            return View(representanteVM);
        }

        //Capturando os dados, gravando no banco e exibindo a mensagem de sucesso.
        [HttpPost]
        public IActionResult Alterar(RepresentanteViewModel representanteVM)
        {
            var representanteModel = mapper.Map<RepresentanteModel>(representanteVM);

            representanteRepository.Update(representanteModel);

            TempData["mensagemSucesso"] = $"Representante {representanteVM.NomeRepresentante} alterado com sucesso";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Excluir(int id)
        {
            representanteRepository.Delete(id);
            TempData["mensagemSucesso"] = $"Representante removido com sucesso";
            return RedirectToAction("Index");
        }

    }
}
