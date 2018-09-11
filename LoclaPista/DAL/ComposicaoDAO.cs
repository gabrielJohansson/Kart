using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoclaPista.DAL
{
    public class ComposicaoDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<ComposicaoCorrida> ListarTodos()
        {
            return ctx.ComposicaoCorrida.ToList();
        }

        public static ComposicaoCorrida ProcurarbyId(int? id)
        {
            return ctx.ComposicaoCorrida.Find(id);
        }

        public static void AdicionarNovo(ComposicaoCorrida p)
        {
            ctx.ComposicaoCorrida.Add(p);
            ctx.SaveChanges();
        }

        public static void Editar(ComposicaoCorrida car, int id)
        {
            ComposicaoCorrida p = ProcurarbyId(id);
            p.p = car.p;
            p.c = car.c;
            
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void Remove(ComposicaoCorrida p)
        {
            ctx.ComposicaoCorrida.Remove(p);
            ctx.SaveChanges();
        }

        public static List<ComposicaoCorrida>BuscarporGuid(string guid)
        {
            return ctx.ComposicaoCorrida.Include("c").Include("p").Where(c=>c.ComposicaoGuid.Equals(guid)).ToList();
        }
    }
}