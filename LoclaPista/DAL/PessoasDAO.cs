using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoclaPista.DAL;
using System.Data.Entity;

namespace LoclaPista.DAL
{
    public class PessoasDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Pessoa> ListarTodas()
        {
            return ctx.Pessoas.ToList();
        }
        public static List<Pessoa> ListarTodasClientes()
        {
            return ctx.Pessoas.Where(p=>p.Adm==0).ToList();
        }
        public static Pessoa ProcurarbyId(int? id)
        {
            return ctx.Pessoas.Find(id);
        }

        public static void AdicionarNovo(Pessoa p)
        {
            //caso precise cadastrar um adm
           // p.Adm = 1;
            ctx.Pessoas.Add(p);
            ctx.SaveChanges();
        }

        public static void Editar(Pessoa pessoa,int id)
        {
            Pessoa p= ProcurarbyId(id);
            p.Nome = pessoa.Nome;
            p.Senha = pessoa.Senha;
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void Remove(Pessoa pessoa)
        {
            ctx.Pessoas.Remove(pessoa);
            ctx.SaveChanges();
        }

        public static Pessoa ProcurarbyCpf(string cpf)
        {
            return ctx.Pessoas.Where(p=>p.Cpf.Equals(cpf)).FirstOrDefault();
        }

        public static Pessoa ProcurarbyCpfSemLoja(string cpf)
        {
            return ctx.Pessoas.Where(p => p.Cpf.Equals(cpf)).FirstOrDefault();
        }

        public static Pessoa Login(Pessoa u)
        {
            return ctx.Pessoas.FirstOrDefault(X => X.Senha.Equals(u.Senha) && X.Cpf.Equals(u.Cpf));
        }
    }
}