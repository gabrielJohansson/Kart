using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoclaPista.DAL
{
    public class PessoaLojaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static void AdicionarNovo(PessoaLoja p)
        {
            ctx.ClienteLoja.Add(p);
            ctx.SaveChanges();
        }
        public static Pessoa ProcurarbyCpf(string cpf, int loja)
        {
            PessoaLoja pe=ctx.ClienteLoja.Include("pessoa").Where(p => p.pessoa.Cpf.Equals(cpf) && p.loja.Id == loja).FirstOrDefault();
            if(pe!=null)
            {
               return  pe.pessoa;
            }
            return null;
        }


        public static List<Pessoa> ListarTodasClientes(int id)
        {
            List<PessoaLoja> pe = ctx.ClienteLoja.Include("pessoa").Where(p => p.pessoa.Adm == 0 && p.loja.Id == id).ToList();

           
            if (pe != null)
            {
                List<Pessoa> pes = new List<Pessoa>();
                for(int i=0;i<pe.Count;i++)
                {
                    pes.Add(pe[i].pessoa);
                }
                return pes;
            }
            return null;
        }

        public static Pessoa Login(Pessoa u, int loja)
        {
           

                PessoaLoja pe = ctx.ClienteLoja.Include("pessoa").FirstOrDefault(X => X.pessoa.Senha.Equals(u.Senha) && X.pessoa.Cpf.Equals(u.Cpf) && X.loja.Id == loja);
                if (pe != null)
                {
                    return pe.pessoa;
                }
                return null;
         
        }
    }
}