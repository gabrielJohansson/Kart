using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoclaPista.Models
{
    public class ComposicaoCorrida
    {
        [Key]
        public int id { get; set; }
        public Pessoa p { get; set; }
        public Carro c { get; set; }
        public string ComposicaoGuid { get; set; }
    }
}