using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoclaPista.Models
{
    public class Pista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime dtaCadastro { get; set; }
        public byte Ativo { get; set; }

    }
}