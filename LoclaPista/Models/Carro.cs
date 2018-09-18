using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoclaPista.Models
{
    public class Carro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string placa { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string modelo { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string marca { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string cor { get; set; }
        public Loja loja { get; set; }
    }
}