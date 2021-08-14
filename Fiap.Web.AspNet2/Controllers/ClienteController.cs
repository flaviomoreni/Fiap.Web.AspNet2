using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ClienteRepository clienteRepository;
        private readonly RepresentanteRepository representanteRepository;

        public ClienteController()
        {
            clienteRepository = new ClienteRepository();
            representanteRepository = new RepresentanteRepository();
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

            return View( new ClienteModel() );
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
            //ViewBag.Representantes = representantes;
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


        /*
        public IActionResult Cadastrar(ClienteModel clienteModel)
        {
            Console.WriteLine("validando o acesso ao controller Cliente e ação Cadastrar");
            Console.WriteLine(clienteModel);
            Console.WriteLine("Gravando no banco de dados e recuperando o id");

            clienteModel.ClienteId = 199; // Fake

            ViewData["ClienteId"] = clienteModel.ClienteId;
            ViewBag.NomeCliente = clienteModel.Nome;
            ViewBag.Mensagem = "Mensagem de teste da ViewBag";

            ViewData["ClienteModel"] = clienteModel;
            ViewBag.ClienteModel = clienteModel;

            TempData["Mensagem"] = "Mensagem de teste da ViewBag";


            //return RedirectToAction("Index");

            return View();
        }
        */

        /*
            public IActionResult Cadastrar(String nome, String email)
            {
                Console.WriteLine("validando o acesso ao controller Cliente e ação Cadastrar");
                Console.WriteLine("Nome do cliente: " + nome);
                Console.WriteLine("Email do cliente: " + email);

                // logAuditoria.cadastrarCliente(nome, email, x, y, z , .... 17);
                // logAuditoria.cadastrarCliente( Cliente );

                // Capturar os dados digitados
                // Validar os dados
                // Gravar os dados no banco de dados
                // bancoDados.gravarCliente(nome, email, x ..... 17); 

                // Exibir a tela sucesso
                return View();
                }
                */


        }




    }
