using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoclaPista.DAL
{
    public class PagamentoDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Pagamento > ListarTodos()
        {
            return ctx.Pagamento.ToList();
        }
        public static Pagamento ProcurarbyId(int? id)
        {
            return ctx.Pagamento.Find(id);
        }
    }
}