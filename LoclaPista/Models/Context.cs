using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoclaPista.Models
{
    public class Context : DbContext
    {
        public Context() : base("BaseAlugueldePista")
        {
        }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<ComposicaoCorrida> ComposicaoCorrida { get; set; }
        public DbSet<Corrida> Corridas { get; set; }
        public DbSet<Pista> Pistas { get; set; }
        public DbSet<TabelaCarroPessoa> CarroPessoa { get; set; }
        public DbSet<HorarioPista> HorarioPista { get; set; }
        public DbSet<Loja> Lojas { get; set; }

        public DbSet<PessoaLoja> ClienteLoja { get; set; }

        
    }
}