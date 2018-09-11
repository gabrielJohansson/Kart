using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoclaPista.Models
{
    public class HorarioPista
    {
        public int id { get; set; }
        public Pista pista { get; set; }
        public DateTime Hora_inicial { get; set; }
        public DateTime Hora_Final { get; set; }
    }
}