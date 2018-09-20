using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoclaPista.DAL
{
    public class CarroPessoaDao
    {
        private static Context ctx = Singleton.Instance.Context;


        public static List<TabelaCarroPessoa> ListarTodos(int id)
        {
            return ctx.CarroPessoa.Include("p").Include("c").Where(p => p.c.loja.Id == id).ToList();
        }

        public static TabelaCarroPessoa ProcurarbyId(int? id)
        {
            return ctx.CarroPessoa.Include("p").Include("c").Where(p=>p.id==id).FirstOrDefault();
        }

        public static void AdicionarNovo(TabelaCarroPessoa p)
        {
            ctx.CarroPessoa.Add(p);
            ctx.SaveChanges();
        }

        public static void Remove(TabelaCarroPessoa p)
        {
            ctx.CarroPessoa.Remove(p);
            ctx.SaveChanges();
        }

        public static List<TabelaCarroPessoa> ProcurarbyPessoa(int id)
        {
            return ctx.CarroPessoa.Include("p").Include("c").Where(p => p.p.Id==id).ToList();
        }

        public static List<TabelaCarroPessoa> ProcurarbyCarro(int id)
        {
            return ctx.CarroPessoa.Where(p => p.c.Id == id).ToList();
        }
        public static TabelaCarroPessoa ProcurarbyExitencia(int id,int id2)
        {
            return ctx.CarroPessoa.Where(p => p.c.Id == id && p.p.Id==id2).FirstOrDefault();
        }
    }
}