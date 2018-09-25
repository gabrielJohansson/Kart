using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoclaPista.DAL
{
    public class PistasDAO
    {
        private static Context ctx = Singleton.Instance.Context;


        public static List<Pista> ListarTodas(int id)
        {
            return ctx.Pistas.Where(p => p.loja.Id == id).ToList();
        }
        public static List<Pista> ListarTodasAtivas(int id)
        {
            return ctx.Pistas.Where(p=>p.Ativo==1 && p.loja.Id==id).ToList();
        }
        public static Pista ProcurarbyId(int? id)
        {
            return ctx.Pistas.Find(id);
        }

        public static void AdicionarNovo(Pista p)
        {
            ctx.Pistas.Add(p);
            ctx.SaveChanges();
        }

        public static void Editar(Pista pista, int id)
        {
            Pista p = ProcurarbyId(id);
            p.Nome = pista.Nome;
            p.Ativo = pista.Ativo;
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void Remove(Pista p)
        {
            ctx.Pistas.Remove(p);
            ctx.SaveChanges();
        }

        public static Pista ProcurarbyNome(string nome)
        {
            return ctx.Pistas.Where(p => p.Nome.Equals(nome)).FirstOrDefault();
        }
    }

}
