using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoclaPista.Models
{
    public class TabelaCarroPessoa
    {
        //tabela que linka todos os carros que a pessoa possui
        //podendo ser compartilhados
        [Key]
        public int id { get; set; }
        public Carro c { get; set; }
        public Pessoa p { get; set; }
        public DateTime dtaCadastro { get; set; }

        public string Concat
        {
            get
            {
                return string.Format("{0} /{1}", p.Nome, c.placa);
            }
        }
        public Loja loja;
    }
}