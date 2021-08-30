using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Fiap.Web.AspNet2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ILojaRepository lojaRepository;
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(ILojaRepository _lojaRepository, IProdutoRepository _produtoRepository)
        {
            lojaRepository = _lojaRepository;
            produtoRepository = _produtoRepository;
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


        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Listando todas as lojas
            var lojas = lojaRepository.FindAll();
            ViewBag.Lojas = new SelectList(lojas, "LojaId", "NomeLoja");

            
            // Consultando o Produto
            var produtoModel = produtoRepository.FindById(id);
            var produtoLojaVM = new ProdutoLojaViewModel();
            produtoLojaVM.Produto = produtoModel;
            produtoLojaVM.LojaId = produtoModel.ProdutoLojas.Select( l => l.LojaId).ToList();

            return View(produtoLojaVM);
        }

        [HttpPost]
        public ActionResult Edit(ProdutoLojaViewModel produtoVM)
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


            produtoRepository.Update(produtoModel);

            TempData["mensagemSucesso"] = "Produto alterado com sucesso";
            return RedirectToAction("Index");
        }

        /*
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
