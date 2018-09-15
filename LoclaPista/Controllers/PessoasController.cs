using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoclaPista.Models;
using LoclaPista.DAL;
using System.Web.Security;

namespace LoclaPista.Controllers
{
    public class PessoasController : Controller
    {

        // GET: Pessoas
        public ActionResult Index(int? id)
        {
            return View(CorridaDAO.ProcurarbyComposicaoPessoa(id));
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = PessoasDAO.ProcurarbyId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Senha,Cpf")] Pessoa pessoa)
        {
            pessoa.Adm = 0;
            pessoa.dtaCadastro = DateTime.Now;
            pessoa.Status = 1;
            if (ModelState.IsValid)
            {
                Pessoa teste = PessoasDAO.ProcurarbyCpf(pessoa.Cpf);
                if (teste == null)
                {
                    PessoasDAO.AdicionarNovo(pessoa);
                    FormsAuthentication.SetAuthCookie(pessoa.Cpf + "|" + pessoa.Id + "|" + pessoa.Adm, true);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Usuário já Cadastrado");
                return View();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = PessoasDAO.ProcurarbyId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Senha")] Pessoa pessoa)
        {
            Pessoa p= PessoasDAO.ProcurarbyId(pessoa.Id);
            p.Nome = pessoa.Nome;
            p.Senha = pessoa.Senha;
            pessoa = p;

                PessoasDAO.Editar(pessoa,pessoa.Id);
                return RedirectToAction("Index");
            
           
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = PessoasDAO.ProcurarbyId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = PessoasDAO.ProcurarbyId(id);
            PessoasDAO.Remove(pessoa);
            return RedirectToAction("Index");
        }
        //carrega Login
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        //Logar
        [HttpPost]
        public ActionResult Login(Pessoa u)
        {
            u.Cpf = Utils.Utilidades.RemoveNaoNumericos(u.Cpf);
            u = PessoasDAO.Login(u);
            if (u != null)
            {
                //Logarr
                FormsAuthentication.SetAuthCookie(u.Cpf+"|"+u.Id+"|"+u.Adm, true);
                return RedirectToAction("Index", "Home");
            }
            //eRRO
            ModelState.AddModelError("", "Algo está errado...");
            return View();
        }

    }
}
