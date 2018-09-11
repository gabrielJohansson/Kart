using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoclaPista.Models
{
    public class Previsao
    {
        public  string dia { get; set; }
        public string tempo { get; set; }
        public string maxima { get; set; }
        public string minima { get; set; }
        public string iuv { get; set; }
    }
}