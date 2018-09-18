using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoclaPista.Models
{
    public class PessoaLoja
    {
        public int Id { get; set; }
        public Loja loja { get; set; }
        public Pessoa pessoa { get; set; }
    }
}