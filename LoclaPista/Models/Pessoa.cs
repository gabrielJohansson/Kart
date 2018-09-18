using LoclaPista.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LoclaPista.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres!")]
        [MaxLength(50, ErrorMessage = "No máximo 50 caracteres!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        //0 normal 1 adm
        //nao vai ser possível cadastrar adm,vai estar cadastrado por fora
        public byte Adm { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres!")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        //será o login,portanto vai ser único   fazer msg para validação de cpf
        [Required(ErrorMessage = "Campo obrigatório!")]
        [ValidacaoCPF(ErrorMessage = "CPF inválido")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        public DateTime dtaCadastro { get; set; }
        public byte Status { get; set; }
       
    }
}