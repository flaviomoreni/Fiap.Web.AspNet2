using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers.Filters
{
    public class FiapFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            //var vm = context.ModelState;
            //var conteudo = Newtonsoft.Json.JsonConvert.SerializeObject(context.ModelState);
            //var conteudoRequest = context.HttpContext.Request.Body.ToString();

            var usuarioLogado = context.HttpContext.Session.GetString("usuarioLogado");
            if ( string.IsNullOrEmpty(usuarioLogado) )
            {
                var controller = context.Controller as Controller;
                controller.HttpContext.Response.Redirect("/Login");
                //controller.RedirectToAction("Index", "Login");
            }
                
            base.OnActionExecuting(context);
        }

    }
}