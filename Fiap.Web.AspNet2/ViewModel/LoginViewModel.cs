using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.ViewModel
{
    public class LoginViewModel
    {
        [Key]
        public int LoginId { get; set; }

        public String Usuario { get; set; }

        public String NomeUsuario { get; set; }

        public String Senha { get; set; }

        public String Token { get; set; }

    }
}
