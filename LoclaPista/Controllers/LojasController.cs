using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LoclaPista.DAL;
using LoclaPista.Models;


namespace LoclaPista.Controllers
{
    public class LojasController : Controller
    {
        private Context db = new Context();

        // GET: Lojas
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                if(Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[2])==1)
                {
                    return View(LojaDAO.Listar(Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name.Split('|')[1])));
                }
             }
            return View(LojaDAO.Listar());
        }


        // GET: Lojas/Create
        public ActionResult Create()
        {
            ViewBag.Pessoa = new Pessoa();
            return View();
        }

        // POST: Lojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Loja loja, Pessoa p)
        {
            p.Adm = 1;
            p.dtaCadastro = DateTime.Now;
            p.Status = 1;
            if (ModelState.IsValid)
            {

                p.Cpf = Utils.Utilidades.RemoveNaoNumericos(p.Cpf);

                Pessoa teste = PessoasDAO.ProcurarbyCpfSemLoja(p.Cpf);
                if (teste == null)
                {
                    PessoasDAO.AdicionarNovo(p);
                    p = PessoasDAO.ProcurarbyCpf(p.Cpf);
                    loja.Dono = p;
                    FormsAuthentication.SetAuthCookie(loja.Dono.Cpf + "|" + loja.Dono.Id + "|" + loja.Dono.Adm, true);
                    Loja l = LojaDAO.ProcurarbyNome(loja.Nome);
                    if (l == null)
                    {
                        LojaDAO.AdicionarNovo(loja);

                        
                        //Cria o Cookie da Loja...

                        //create a cookie
                        HttpCookie Loja = new HttpCookie("Loja");
                        l = LojaDAO.ProcurarbyNome(loja.Nome);


                        PessoaLoja pl = new PessoaLoja();

                        pl.loja = l;
                        pl.pessoa = p;

                        PessoaLojaDAO.AdicionarNovo(pl);


                        //Add key-values in the cookie
                        Loja.Values.Add("lojaId", l.Id.ToString());
                        Loja.Expires = DateTime.Now.AddYears(1);
                        //Most important, write the cookie to client.
                        Response.Cookies.Add(Loja);

                        //Recupera ele na hora de entrar na loja,mudar o cookie ao trocar de loja
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Loja já Cadastrada");
                    return View();
                }
                ModelState.AddModelError("", "Usuário já Cadastrado");
                return View();


            }

            return View(loja);
        }

        public ActionResult Entrar(int id)
        {
            HttpCookie Loja = new HttpCookie("Loja");
            Loja.Values.Add("lojaId", id.ToString());
            Loja.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(Loja);
            return RedirectToAction("Index","Home");
        }

       
     

    }
}