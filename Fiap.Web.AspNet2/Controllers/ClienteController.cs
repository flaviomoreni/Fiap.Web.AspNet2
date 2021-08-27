using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ClienteRepository clienteRepository;
        private readonly RepresentanteRepository representanteRepository;

        public ClienteController()
        {
            clienteRepository = new ClienteRepository();

            //representanteRepository = new RepresentanteRepository();
            representanteRepository = null;
        }


        [HttpGet]
        public IActionResult Index()
        {

            Console.WriteLine("validando o acesso ao controller Home e ação Index");

            IList<ClienteModel> clientes = clienteRepository.FindAll();

            return View(clientes);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            IList<RepresentanteModel> representantes = representanteRepository.FindAll();
            ViewBag.Representantes = representantes;

            return View(new ClienteModel());
        }

        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {
            clienteRepository.Insert(clienteModel);

            TempData["mensagemSucesso"] = $"Cliente {clienteModel.Nome} cadastrado com sucesso";
            return RedirectToAction("Index");
        }


        // Abrindo a tela de alteração
        [HttpGet]
        public IActionResult Alterar(int id)
        {
            ClienteModel clienteModel = clienteRepository.FindById(id);

            IList<RepresentanteModel> representantes = representanteRepository.FindAll();
            ViewBag.Representantes = new SelectList(representantes, "RepresentanteId", "NomeRepresentante");

            return View(clienteModel);
        }

        //Capturando os dados, gravando no banco e exibindo a mensagem de sucesso.
        [HttpPost]
        public IActionResult Alterar(ClienteModel clienteModel)
        {
            clienteRepository.Update(clienteModel);

            TempData["mensagemSucesso"] = $"Cliente {clienteModel.Nome} alterado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var clienteModel = clienteRepository.FindById(id);
            return View(clienteModel);
        }


        [HttpGet]
        public IActionResult Excluir(int id)
        {
            clienteRepository.Delete(id);
            TempData["mensagemSucesso"] = $"Cliente removido com sucesso";
            return RedirectToAction("Index");
        }


    }

}
