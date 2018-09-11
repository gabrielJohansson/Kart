using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoclaPista.Models
{
    public class Corrida
    {
        [Key]
        public int Id { get; set; }
        public DateTime DtaCadastro { get; set; }
        public DateTime DtaCorrida { get; set; }
        public DateTime DtaCancelamento { get; set; }
        public Pessoa Responsavel { get; set; }
        public Pista Pista { get; set; }
        public string ComposicaoGuid { get; set; }
        public double Preco { get; set; }

        public Pagamento pagamento { get; set; }
    }
}