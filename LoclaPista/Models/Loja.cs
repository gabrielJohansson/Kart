using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoclaPista.Models
{
    public class Loja
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Pessoa Dono { get; set; }


        public  Loja()
        {
            Pessoa Dono = new Pessoa();
        }
    }
}