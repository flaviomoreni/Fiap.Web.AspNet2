using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly LojaRepository lojaRepository;
        private readonly ProdutoRepository produtoRepository;

        public ProdutoController()
        {
            lojaRepository = new LojaRepository();
            produtoRepository = new ProdutoRepository();

        }



        public ActionResult Index()
        {
            return View( produtoRepository.FindAll() );
        }

        public ActionResult Details(int id)
        {
            return View( produtoRepository.FindById(id) );
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Lojas = lojaRepository.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProdutoLojaViewModel produtoVM)
        {
            ProdutoModel produtoModel = produtoVM.Produto;
            produtoModel.ProdutoLojas = new List<ProdutoLojaModel>();

            foreach (var loja in produtoVM.LojaId)
            {
                var produtoLojaModel = new ProdutoLojaModel()
                {
                    LojaId = loja,
                    Produto = produtoModel
                };

                produtoModel.ProdutoLojas.Add(produtoLojaModel);
            }


            produtoRepository.Insert(produtoModel);

            TempData["mensagemSucesso"] = "Produto cadastrado com sucesso";
            return RedirectToAction("Index");
        }

        /*
        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
