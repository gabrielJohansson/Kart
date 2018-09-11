using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LoclaPista.Models
{
    [Serializable, XmlRoot("cidade")]
    public class Tempo
    {
        public string nome { get; set; }
        public string uf { get; set; }
        public string atualizacao { get; set; }
        [XmlElement("previsao")]
        public List<Previsao> previsao { get; set; }
    }
}