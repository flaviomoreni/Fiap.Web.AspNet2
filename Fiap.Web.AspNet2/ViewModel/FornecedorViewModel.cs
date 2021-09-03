using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.ViewModel
{
    public class FornecedorViewModel
    {
        [Key]
        public int FornecedorId { get; set; }

        [Display(Name ="CNPJ")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "O campo CNPJ é requerido")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$", ErrorMessage = "CNPJ no formato inválido")]
        public String Cnpj { get; set; }

        [Display(Name = "Razão Social")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Razão Social é requerido")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "A razão social deve ter entre 2 ou 30 caracteres")]
        public String RazaoSocial { get; set; }

        [Display(Name = "Telefone (99) 99999-9999")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Telefone é requerido")]
        public String Telefone { get; set; }

        [Display(Name = "Endereço")]
        public String Endereco { get; set; }

        [Display(Name = "e-mail")]
        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Display(Name = "Data de abertura")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAbertura { get; set; }

        [Display(Name = "Capital Social")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public Decimal ValorCapitalSocial { get; set; }

        [Display(Name = "Número de funcionários")]
        [Range(10,100000, ErrorMessage = "Permitido apenas empresas com no mínimo 10 funcionários")]
        public int QuantidadeFuncionarios { get; set; }
    }

}
