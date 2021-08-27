using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Controllers
{
    public class RepresentanteController : Controller
    {
        private readonly IRepresentanteRepository representanteRepository;

        public RepresentanteController( IRepresentanteRepository _representanteRepository )
        {
            representanteRepository = _representanteRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            IList<RepresentanteModel> clientes = representanteRepository.FindAll();

            return View(clientes);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View(new RepresentanteModel());
        }

        [HttpPost]
        public IActionResult Novo(RepresentanteModel representanteModel)
        {
            representanteRepository.Insert(representanteModel);

            TempData["mensagemSucesso"] = $"Representante {representanteModel.NomeRepresentante} cadastrado com sucesso";
            return RedirectToAction("Index");
        }


        // Abrindo a tela de alteração
        [HttpGet]
        public IActionResult Alterar(int id)
        {
            RepresentanteModel representanteModel = representanteRepository.FindById(id);

            return View(representanteModel);
        }

        //Capturando os dados, gravando no banco e exibindo a mensagem de sucesso.
        [HttpPost]
        public IActionResult Alterar(RepresentanteModel representanteModel)
        {
            representanteRepository.Update(representanteModel);

            TempData["mensagemSucesso"] = $"Representante {representanteModel.NomeRepresentante} alterado com sucesso";
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
