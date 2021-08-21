using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            DataContext context = new DataContext();

            var produtoModel = context.Produto
                .Include(p => p.ProdutoLojas)
                    .ThenInclude( o => o.Loja )
                .SingleOrDefault(p => p.ProdutoId == 1);

            var lojaModel = context.Loja
                .Include(l => l.ProdutoLojas)
                .ThenInclude(p => p.Produto).ToList();


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
