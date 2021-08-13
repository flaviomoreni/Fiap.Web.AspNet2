using Fiap.Web.AspNet2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("validando o acesso ao controller Home e ação Index");
            // if ( user.hasAccess("clientes-listar") ) { }
            return View();
        }


        public IActionResult Novo()
        {
            return View();
        }


        public IActionResult Cadastrar(ClienteModel clienteModel)
        {
            TempData["mensagemSucesso"] = $"Cliente {clienteModel.Nome} cadastrado com sucesso";

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
