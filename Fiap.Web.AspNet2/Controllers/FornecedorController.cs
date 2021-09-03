using Fiap.Web.AspNet2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class FornecedorController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FornecedorViewModel fornecedorViewModel)
        {
            /*
            if ( string.IsNullOrWhiteSpace( fornecedorViewModel.Cnpj ) )
            {
                ModelState.AddModelError("Cnpj", "Cnpj não pode ser nulo");
            } 
            
            if (string.IsNullOrWhiteSpace(fornecedorViewModel.RazaoSocial))
            {
                ModelState.AddModelError("RazaoSocial", "Razão não pode ser nula");
            }

            if (string.IsNullOrWhiteSpace(fornecedorViewModel.Telefone))
            {
                ModelState.AddModelError("Telefone", "Telefone não pode ser nulo");
            }
            */

                
            if ( ModelState.IsValid )
            {
                return RedirectToAction("Index", "Home");
            } else
            {
                // var modelState = Newtonsoft.Json.JsonConverter()

                //return Json(ModelState);
                return View();
            }
            
        }

    }
}
