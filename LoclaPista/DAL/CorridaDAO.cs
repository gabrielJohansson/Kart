using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoclaPista.DAL
{
    public class CorridaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Corrida> ListarTodos()
        {
            return ctx.Corridas.ToList();
        }
        public static List<Corrida> ListarTodosData()
        {
            return ctx.Corridas.Where(p=>p.DtaCorrida>DateTime.Now &&p.DtaCancelamento==p.DtaCadastro).ToList();
        }

        public static Corrida ProcurarbyId(int? id)
        {
            return ctx.Corridas.Find(id);
        }

        public static void AdicionarNovo(Corrida p)
        {
            ctx.Corridas.Add(p);
            ctx.SaveChanges();
        }

        public static void Editar(Corrida car, int id)
        {
            Corrida p = ProcurarbyId(id);
            p.Pista = car.Pista;
            p.Preco = car.Preco;
            p.Responsavel = car.Responsavel;
            p.DtaCorrida = car.DtaCorrida;
            p.DtaCancelamento = car.DtaCancelamento;
            p.DtaCadastro = car.DtaCadastro;
            p.ComposicaoGuid = car.ComposicaoGuid;
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void Cancela(int id)
        {
            Corrida p = ProcurarbyId(id);
            p.DtaCancelamento = DateTime.Now;
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void Remove(Corrida p)
        {
            ctx.Corridas.Remove(p);
            ctx.SaveChanges();
        }

        public static List<Corrida> ProcurarbyResponsavel(int id)
        {
            return ctx.Corridas.Where(p => p.Responsavel.Id==id).ToList();
        }
        public static List<Corrida> ProcurarbyComposicaoPessoa(int? id)
        {
            return ctx.Corridas.Include("Responsavel").Include("Pista").Include("pagamento").Where(p => p.Responsavel.Id == id).ToList();
        }
        public static List<Corrida> ProcurarbyComposicaoCarro(string id)
        {
            return ctx.Corridas.Where(p => p.ComposicaoGuid == id).ToList();
        }

        public static List<Corrida> ProcurarbyPista(int id)
        {
            return ctx.Corridas.Where(p => p.Pista.Id == id).ToList();
        }

        public static List<Corrida> ProcurarbyDtaCorridas(DateTime id)
        {
            return ctx.Corridas.Where(p => p.DtaCorrida == id).ToList();
        }
        public static Corrida ProcurarbyDtaCorrida(DateTime id)
        {
            return ctx.Corridas.Where(p => p.DtaCorrida == id).FirstOrDefault();
        }

        public static List<Corrida> ProcurarbyAtivo()
        {
            DateTime id = DateTime.Now;
            return ctx.Corridas.Include("Responsavel").Include("Pista").Include("pagamento").Where(p => p.DtaCorrida > id && p.DtaCadastro==p.DtaCancelamento).ToList();
        }

        public static List<Corrida> ProcurarbyPagamento(int id)
        {
            return ctx.Corridas.Include("Responsavel").Include("Pista").Include("pagamento").Where(p => p.pagamento.Id==id).ToList();
        }
    }
}