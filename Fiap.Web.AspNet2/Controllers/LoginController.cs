using Fiap.Web.AspNet2.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {

            if ( loginViewModel.Usuario.Equals("admin") && loginViewModel.Senha.Equals("1234")) 
            {
                loginViewModel.NomeUsuario = "Usuário Admin do Site";
                HttpContext.Session.SetString("usuarioLogado", loginViewModel.NomeUsuario);

                TempData["mensagemSucesso"] = $"Login efetuado com sucesso";
            } else
            {
                HttpContext.Session.Clear();
                TempData["mensagemSucesso"] = $"Usuário ou senha inválida";
            }

            return RedirectToAction("Index");
        }

    }
}
