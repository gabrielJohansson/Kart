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
            return View(db.Lojas.ToList());
        }

        // GET: Lojas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
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
        public ActionResult Create([Bind(Include = "Id,Nome")] Loja loja,Pessoa p)
        {
            p.Adm = 1;
            p.dtaCadastro = DateTime.Now;
            p.Status = 1;
            if (ModelState.IsValid)
            {

                p.Cpf = Utils.Utilidades.RemoveNaoNumericos(p.Cpf);

                Pessoa teste = PessoasDAO.ProcurarbyCpf(p.Cpf);
                if (teste == null)
                {
                    PessoasDAO.AdicionarNovo(p);
                    loja.Dono = p;
                    FormsAuthentication.SetAuthCookie(loja.Dono.Cpf + "|" + loja.Dono.Id + "|" + loja.Dono.Adm, true);
                    Loja l = LojaDAO.ProcurarbyNome(loja.Nome);
                    if (l == null)
                    {
                        LojaDAO.AdicionarNovo(loja);


                        //Cria o Cookie da Loja...

                        //create a cookie
                        HttpCookie myCookie = new HttpCookie("Loja");
                        l = LojaDAO.ProcurarbyNome(loja.Nome);
                        //Add key-values in the cookie
                        myCookie.Values.Add("lojaId", l.Id.ToString());
                        myCookie.Expires = DateTime.Now.AddYears(1);
                        //Most important, write the cookie to client.
                        Response.Cookies.Add(myCookie);

                        //Recupera ele na hora de entrar na loja,mudar o cookie ao trocar de loja

                        //Recupera ele assim----


                        ////Assuming user comes back after several hours. several < 12.
                        ////Read the cookie from Request.
                        //HttpCookie myCookie = Request.Cookies["myCookie"];
                        //if (myCookie == null)
                        //{
                        //    //No cookie found or cookie expired.
                        //    //Handle the situation here, Redirect the user or simply return;
                        //}

                        ////ok - cookie is found.
                        ////Gracefully check if the cookie has the key-value as expected.
                        //if (!string.IsNullOrEmpty(myCookie.Values["userid"]))
                        //{
                        //    string userId = myCookie.Values["userid"].ToString();
                        //    //Yes userId is found. Mission accomplished.
                        //}





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

        // GET: Lojas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loja);
        }

        // GET: Lojas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loja loja = db.Lojas.Find(id);
            db.Lojas.Remove(loja);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
