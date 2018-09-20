using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoclaPista.DAL
{
    public class LojaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static void AdicionarNovo(Loja p)
        {
            //caso precise cadastrar um adm
            // p.Adm = 1;
            ctx.Lojas.Add(p);
            ctx.SaveChanges();
        }

        public static Loja ProcurarbyNome(string nome)
        {
            return ctx.Lojas.Where(p => p.Nome.Equals(nome)).FirstOrDefault();
        }
             public static Loja ProcurarbyId(int? id)
        {
            return ctx.Lojas.Find(id);
        }

        public static List<Loja> Listar()
        {
            return ctx.Lojas.ToList();
        }

        public static List<Loja> Listar(int id)
        {
            return ctx.Lojas.Where(p=>p.Dono.Id==id).ToList();
        }
    }
    }
